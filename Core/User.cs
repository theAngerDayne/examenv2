using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
    public class User
    {
        public int Id { get; set; }
        
        
        public string Username { get; set; }                
        
        [Required]
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime UltimoAcceso { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
    }
}
