using AutoMapper;
using DiplomskiRad.DTOS;
using DiplomskiRad.Entities;
using DiplomskiRad.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DiplomskiRad.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReservationController : ControllerBase 
    { 
        private readonly IReservationService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(IReservationService service, IMapper mapper, ILogger<ReservationController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("adding/reservation")]
        public async Task<ActionResult> AddNewReservation([FromBody] ReservationWriteDto reservationWriteDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var newReservation = _mapper.Map<Reservation>(reservationWriteDto);
                newReservation.AppUserId = Convert.ToInt32(userId);
                var result = await _service.CreateReservation(newReservation);
                if (result)
                {
                    return StatusCode(201);
                }
                else
                {
                    return StatusCode(400);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Reservation/adding/reservation");
                return StatusCode(500);
            }
        }

        [HttpGet("all-reservations")]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetAllReservations()
        {
            try
            {
                var reservations = await _service.GetAllReservationsAsync();
                var mappedReservation = _mapper.Map<IEnumerable<ReservationReadDto>>(reservations);
                return Ok(mappedReservation);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Reservation/all-reservations");
                return StatusCode(500);
            }
        }

        [HttpGet("reservations-user")]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetAllReservationsForUser()
        {
            try
            {
                var reservations = await _service.GetAllReservationsUserAsync();
                var mappedReservation = _mapper.Map<IEnumerable<ReservationReadDto>>(reservations);
                return Ok(mappedReservation);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Reservation/reservation-user");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationReadDto>> GetReservationById(int id)
        {
            try
            {
                var reservation = await _service.GetReservationById(id);
                    _mapper.Map<ReservationReadDto>(reservation);
                    return Ok();
                
            }
            catch(Exception e)
            {
                _logger.LogError(e, "GET: /api/Reservation/{id}");
                return StatusCode(500);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservationById(int id)
        {
            try
            {
                var result = await _service.DeleteReservationById(id);
                if(!result)
                {
                    return BadRequest("Deleting reservation failed");
                }
                return NoContent();
            }
            catch(Exception e)
            {
                _logger.LogError(e, "GET: /api/Reservation/{id}");
                return StatusCode(500);
            }
        }
    }
   

}
