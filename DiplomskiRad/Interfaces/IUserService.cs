using DiplomskiRad.DTOS;
using DiplomskiRad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Interfaces
{
    public interface IUserService
    {
     
        Task<AppUser> GetUserByIdAsync(int id);
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<bool> RegisterUserAsync(RegisterDto registerDto);
        Task<UserDto> LoginUserAsync(LoginDto loginDto);
        Task<bool> UserExists(string username);

    }
}
