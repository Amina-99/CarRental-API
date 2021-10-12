using AutoMapper;
using DiplomskiRad.Data;
using DiplomskiRad.DTOS;
using DiplomskiRad.Entities;
using DiplomskiRad.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DiplomskiRad.Services
{
    public class ReservationService : IReservationService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public ReservationService(DataContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext=httpContext; 
        }
        public async Task<bool> CreateReservation(Reservation reservation)
        {
            var associatedCar = await _context.Cars.Include(c => c.Reservations).
                SingleOrDefaultAsync(c =>c.Id==reservation.CarId && !c.Reservations.
                Any(r => (r.StartDate <= reservation.StartDate && r.EndDate >= reservation.StartDate) ||
                (r.StartDate >= reservation.StartDate && r.StartDate <= reservation.EndDate)));
               // SingleOrDefaultAsync(c => c.Id == reservation.CarId && !c.Reservations.
               //Any(c => (c.StartDate <= reservation.StartDate && c.EndDate >= reservation.EndDate) || 
               //(c.StartDate >= reservation.StartDate && c.EndDate >= reservation.EndDate) ||
               //(c.StartDate <= reservation.StartDate && c.EndDate <= reservation.EndDate) ||
               //(c.StartDate > reservation.StartDate && c.EndDate <= reservation.EndDate)));
               // Any(c => (c.StartDate > reservation.StartDate || c.StartDate < reservation.EndDate) && 
               //(c.EndDate > reservation.StartDate || c.EndDate < reservation.EndDate)));
            if (associatedCar == null)
            {
                return false;
            }
            var dateRange = (reservation.EndDate - reservation.StartDate).TotalDays;
            reservation.DateRange = Convert.ToInt32(dateRange);
            reservation.Total = associatedCar.PricePerDay * reservation.DateRange;
            reservation.CarId = associatedCar.Id;
            await _context.Reservations.AddAsync(reservation);
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<bool> DeleteReservationById(int id)
        {
            var reservation = await _context.Reservations.SingleOrDefaultAsync(r => r.Id == id);
            if(reservation == null)
            {
                return false;
            }
            reservation.IsDeleted = true;
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<IEnumerable<ReservationReadDto>> GetAllReservationsAsync()
        {
            var reservations = await _context.Reservations.Where(r=> r.IsDeleted==false)
                .Include(t => t.AppUser)
                .Include(t => t.Car)
                .Select(t => new ReservationReadDto 
                { Id=t.Id,
                  CustomerName = t.AppUser.UserName, 
                  CarName=t.Car.Name, 
                  CarId=t.Car.Id,
                  StartDate=t.StartDate,
                  EndDate=t.EndDate, 
                  DateRange=t.DateRange, 
                  PricePerDay=t.Car.PricePerDay, 
                  Total=t.DateRange*t.Car.PricePerDay
                   })
                .ToListAsync();
            return reservations;
        }

        public async Task<IEnumerable<ReservationReadDto>> GetAllReservationsUserAsync()
        {
            var thisDay = DateTimeOffset.UtcNow.Date;
            var reservation = await _context.Reservations.Where(r => (r.IsDeleted == false) 
            && (r.StartDate > thisDay)
            && (r.EndDate > thisDay)).
            Include(r => r.Car).
                Select(r => new ReservationReadDto
                {   Id=r.Id,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    CarId=r.CarId
                }).ToListAsync();
            return reservation;
        }
        public async Task<Reservation> GetReservationById(int id)
        {
            var reservation=await _context.Reservations.FindAsync(id);
            return reservation;
        }
    }
       
}
