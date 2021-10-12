using AutoMapper;
using DiplomskiRad.Data;
using DiplomskiRad.Entities;
using DiplomskiRad.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Services
{
    public class UserService: IUserService
    {
        private readonly DataContext _context;
     
        public UserService(DataContext context)
        {
            _context = context;
           
        }
        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            var users = _context.Users.Include(u=> u.Reservations).
            Where(u => u.RolaId ==2).ToListAsync();
            return await users;
        }
        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}