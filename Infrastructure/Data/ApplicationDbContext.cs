using Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Utility.CreatePasswordHash("123456", out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<User>().HasData(
              new User { Id = 100, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "Angel", Email = "angel@duoc.cl" },
              new User { Id = 101, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "ProfeMoises", Email = "profe.moises@duoc.cl" }
          );

        }

     }
}

