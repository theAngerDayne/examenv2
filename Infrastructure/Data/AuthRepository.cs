using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Infrastructure.Dtos.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AuthRepository(ApplicationDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            User user = await _context.User.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
            if (user == null)
            {
                response.Success = false;
                response.Message = "Usuario no encontrado.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Contraseña erronea"; //en aplicaciones reales, no deberia enviar ningun mensaje
            }
            else
            {
                response.Message = "Token creado";
                response.Data = CreateToken(user);
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();

            if (await UserExists(user.Email))
            {
                response.Success = false;
                response.Message = "Usuario ya existe.";
                return response;
            }

            Utility.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            response.Message = "Usuario creado";
            response.Data = user.Id; //retorno id... supongo
            return response;
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.User.AnyAsync(x => x.Email.ToLower() == email.ToLower()))
            {
                return true;
            }
            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)
            );

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1), //hare que expire en 1 dia
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();

            List<User> dbUser = await _context.User.ToListAsync();

            serviceResponse.Data = (dbUser.Select(c => _mapper.Map<GetUserDto>(c))).ToList();

            return serviceResponse;
        }

      
    }
}