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
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<IEnumerable<AppUser>> GetUsersAsync();

    }
}
