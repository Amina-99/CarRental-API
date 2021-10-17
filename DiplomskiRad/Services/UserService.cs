using AutoMapper;
using DiplomskiRad.Data;
using DiplomskiRad.DTOS;
using DiplomskiRad.Entities;
using DiplomskiRad.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DiplomskiRad.Services
{
    public class UserService: IUserService
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly ILogger<UserService> _logger;

        public UserService(DataContext context, ITokenService tokenService, ILogger<UserService> logger)
        {
            _context = context;
            _tokenService = tokenService;
            _logger = logger;
           
        }
        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            try
            {
                var users = _context.Users.Include(u => u.Reservations).
                Where(u => u.RolaId == 2).ToListAsync();
                return await users;
            }
            catch (Exception e)
            {
                _logger.LogError(e, nameof(GetUsersAsync));
                throw;
            }
        }
        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            try
            {
                return await _context.Users.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, nameof(GetUserByIdAsync));
                throw;
            }
        }

        public async Task<bool> RegisterUserAsync(RegisterDto registerDto)
        {
            try
            {
                using var hmac = new HMACSHA512();
                var user = new AppUser
                {
                    UserName = registerDto.Username.ToLower(),
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                    PasswordSalt = hmac.Key,
                    RolaId = 2

                };
                _context.Users.Add(user);
                return await _context.SaveChangesAsync() >= 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e, nameof(RegisterUserAsync));
                throw;
            }
        }

        public async Task<UserDto> LoginUserAsync(LoginDto loginDto)
        {
            try
            {
                var user = await _context.Users.Include(u => u.Rola).SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
                if (user == null) return null;
                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i]) return null;
                }
                return new UserDto
                {
                    Username = user.UserName,
                    Token = _tokenService.CreateToken(user),
                    RolaId = user.Rola.Id
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, nameof(LoginUserAsync));
                throw;
            }
        }
        public async Task<bool> UserExists(string username)
        {
            try
            {
                return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
            }
            catch (Exception e)
            {
                _logger.LogError(e, nameof(UserExists));
                throw;
            }
        }
    }
}