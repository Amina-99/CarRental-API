using DiplomskiRad.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DiplomskiRad.Data
{
    public class DataContext : DbContext
    {
        DataContext()
        {

        }
        public DataContext(DbContextOptions options) : base(options)
        { 
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name="Admin"
                });
            modelBuilder.Entity<Role>().HasData(
               new Role
               {
                   Id = 2,
                   Name = "User"
               });
            using var hmac = new HMACSHA512();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {    
                 PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("admin")),
                 PasswordSalt = hmac.Key,
                 RolaId=1, 
                 UserName="Admin", 
                 Id=5
            });
        }

    }
}
