using AutoMapper;
using DiplomskiRad.Data;
using DiplomskiRad.DTOS;
using DiplomskiRad.Entities;
using DiplomskiRad.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService service, IMapper mapper, ILogger<UsersController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            try
            {
                var users = await _service.GetUsersAsync();
                var newUsers = _mapper.Map<IEnumerable<UserDto>>(users);
                return Ok(newUsers);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Users/users");
                return StatusCode(500);
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserById(int id)
        {
            try
            {
                var user = await _service.GetUserByIdAsync(id);
                return user;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Users/{id}");
                return StatusCode(500);
            }
        }
    }
}
