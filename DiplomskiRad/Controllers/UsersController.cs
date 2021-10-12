using AutoMapper;
using DiplomskiRad.Data;
using DiplomskiRad.DTOS;
using DiplomskiRad.Entities;
using DiplomskiRad.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Controllers
{
    
    public class UsersController : BaseApiController
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UsersController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
      
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _service.GetUsersAsync();
            var newUsers = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(newUsers);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserById(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            return user;
        }
    }
}
