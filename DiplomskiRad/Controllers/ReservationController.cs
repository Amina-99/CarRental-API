using AutoMapper;
using DiplomskiRad.DTOS;
using DiplomskiRad.Entities;
using DiplomskiRad.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DiplomskiRad.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReservationController : BaseApiController
    {
        private readonly IReservationService _service;
        private readonly IMapper _mapper;
        
        public ReservationController(IReservationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost("adding/reservation")]
        public async Task<ActionResult> AddNewReservation([FromBody] ReservationWriteDto reservationWriteDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var newReservation = _mapper.Map<Reservation>(reservationWriteDto);
            newReservation.AppUserId = Convert.ToInt32(userId);
            var result= await _service.CreateReservation(newReservation);
            if (result)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }
        }
        [HttpGet("allReservations")]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetAllReservations()
        {
            var reservations = await _service.GetAllReservationsAsync();
            var mappedReservation= _mapper.Map<IEnumerable<ReservationReadDto>>(reservations);
            return Ok(mappedReservation);
        }
        [HttpGet("reservationsUser")]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetAllReservationsForUser()
        {
            var reservations = await _service.GetAllReservationsUserAsync();
            var mappedReservation = _mapper.Map<IEnumerable<ReservationReadDto>>(reservations);
            return Ok(mappedReservation);
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
                return BadRequest("Something went wrong: "+e.Message);
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
                return BadRequest("Something went wrong: " + e.Message);
            }
        }
    }
   

}
