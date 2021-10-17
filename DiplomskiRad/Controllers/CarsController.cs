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
    public class CarsController : ControllerBase
    {
        private readonly ICarService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<CarsController> _logger;

        public CarsController(ICarService service, IMapper mapper, ILogger<CarsController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("cars")]
        public async Task<ActionResult<IEnumerable<CarReadDto>>> GetAllCarsAsync()
        {
            try
            {
                var cars = await _service.GetCarsAsync();
                var listOfCars = _mapper.Map<IEnumerable<CarReadDto>>(cars);
                return Ok(listOfCars);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Cars/cars");
                return StatusCode(500);
            }
        }

        [HttpGet("all-cars")]
        public async Task<IActionResult> GetCars(int? page, DateTime? startDate, DateTime? endDate, int pagesize = 6)
        {
            try
            {
                var cars = await _service.GetCars(page, startDate, endDate, pagesize);
                return Ok(cars);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Cars/all-cars");
                return StatusCode(500);
            }

        }

        [HttpPost("adding")]
        public async Task<IActionResult> AddNewCar([FromBody] CarWriteDto carWriteDto)
        {
            try
            {
                var newCar = _mapper.Map<Car>(carWriteDto);
                await _service.AddCarAsync(newCar);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Cars/adding");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            try
            {
                var result = await _service.DeleteCarById(id);
                if (!result)
                {
                    return BadRequest("Deleting car failed");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Cars/{id}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarReadDto>> GetCarById(int id)
        {   
            try
            {
                var car = await _service.GetCarByIdAsync(id);
                var newCar = _mapper.Map<CarReadDto>(car);
                return Ok(newCar);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Cars/{id}");
                return StatusCode(500);
            }
        }

        [HttpPut("editing/{id}")]
        public async Task<IActionResult>EditCarAsync(int id, CarWriteDto carWriteDto)
        {
            try
            {
                var result = await _service.UpdateByIdAsync(id, carWriteDto);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Cars/editing/{id}");
                return StatusCode(500);
            }
        }
    }
    
}

