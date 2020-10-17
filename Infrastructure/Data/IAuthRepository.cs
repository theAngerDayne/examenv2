using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Infrastructure.Dtos.User;

namespace Infrastructure.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<bool> UserExists(string username);
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();
        
    }
}