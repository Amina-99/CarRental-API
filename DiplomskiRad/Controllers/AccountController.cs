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

namespace DiplomskiRad.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IUserService userService, ILogger<AccountController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            try
            {
                if (await _userService.UserExists(registerDto.Username)) return BadRequest("Username is taken");

                if (await _userService.RegisterUserAsync(registerDto))
                {
                    return Ok();
                }
                else return BadRequest("Something went wrong");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Account/register");
                return StatusCode(500);
            }

        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _userService.LoginUserAsync(loginDto);
                if (user == null)
                    return BadRequest("Invalid username or password");
                else
                    return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Account/login");
                return StatusCode(500);
            }
        }

     
    }
  
   
}
