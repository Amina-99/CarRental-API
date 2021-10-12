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
    public class CarsController : BaseApiController
    {
        private readonly ICarService _service;
        private readonly IMapper _mapper;
        public CarsController(ICarService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("cars")]
        public async Task<ActionResult<IEnumerable<CarReadDto>>> GetAllCarsAsync()
        {
            var cars = await _service.GetCarsAsync();
            var listOfCars = _mapper.Map<IEnumerable<CarReadDto>>(cars);
            return Ok(listOfCars);
        }
        [HttpGet("carsByDate")]
        public async Task<ActionResult<IEnumerable<CarReadDto>>> GetCarsByDate(DateTime startDate, DateTime endDate)
        {
            var cars = await _service.GetCarsByDateAsync(startDate, endDate);
            var listOfCars = _mapper.Map<IEnumerable<CarReadDto>>(cars);
            return Ok(listOfCars);
        }
        [HttpGet("AllCars")]
        public async Task<IActionResult> GetCars(int? page, DateTime? startDate, DateTime? endDate, int pagesize = 6)
       {
            var cars = await _service.GetCars(page, startDate, endDate, pagesize);
            return Ok(cars);
        }
        [HttpPost("adding")]
        public async Task<IActionResult> AddNewCar([FromBody] CarWriteDto carWriteDto)
        {
            var newCar = _mapper.Map<Car>(carWriteDto);
            await _service.AddCarAsync(newCar);
            return StatusCode(201);
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
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CarReadDto>> GetCarById(int id)
        {
            var car = await _service.GetCarByIdAsync(id);
            var newCar=_mapper.Map<CarReadDto>(car);
            return Ok(newCar);
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
                return BadRequest("Something went wrong: " + e.Message);
            }
        }
    }
    
}

