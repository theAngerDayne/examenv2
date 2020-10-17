using System;

namespace Infrastructure.Dtos.User
{
    public class GetUserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime UltimoAcceso { get; set; }
    }
}