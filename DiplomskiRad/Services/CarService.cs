using AutoMapper;
using DiplomskiRad.Data;
using DiplomskiRad.DTOS;
using DiplomskiRad.Entities;
using DiplomskiRad.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Services
{
    public class CarService : ICarService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CarService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            var thisDay = DateTime.Now;
            var car = await _context.Cars.Where(c=> c.IsDeleted==false).Include(c => c.Reservations.
            Where(r=> (r.StartDate> thisDay) && (r.IsDeleted==false))).FirstOrDefaultAsync(c => c.Id == id);
            return car;
        }
        public async Task<IEnumerable<Car>>GetCarsByDateAsync(DateTime StartDate, DateTime EndDate)
        {
        var associatedCar = await _context.Cars.Where(c=> c.IsDeleted==false).Include(c => c.Reservations).
                Where(c => !c.Reservations.
                Any(r => (r.StartDate <= StartDate && r.EndDate >= StartDate) ||
                (r.StartDate >= StartDate && r.StartDate <= EndDate))).ToListAsync();
            if(associatedCar == null)
            {
                return null;
            }
            return associatedCar; 
          
        }

        public async Task<IEnumerable<Car>> GetCarsAsync()
        {
            var cars = await _context.Cars.Where(c=> c.IsDeleted==false).Include(c => c.Reservations).ToListAsync();
            return cars;
        }

        public async Task<bool> AddCarAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            return await _context.SaveChangesAsync() >= 0;
        }


        public async Task<bool> DeleteCarById(int id)
        {
            var car = await _context.Cars.SingleOrDefaultAsync(c => c.Id == id);
            if(car == null)
            {
                return false;
            }
            car.IsDeleted = true;
            return await _context.SaveChangesAsync() >= 0;

        }
        public async Task<PageResult<CarReadDto>> GetCars(int? page, DateTime? startDate, DateTime? endDate, int pagesize = 6)
        {
            var countDetails = await _context.Cars.Where(c => c.IsDeleted == false).CountAsync();
            IQueryable<Car> ItemsList = _context.Cars.Where(c => c.IsDeleted == false).Include(c => c.Reservations);
            if (startDate != null && endDate != null)
            {
                ItemsList = ItemsList.
                Where(c => !c.Reservations.
                Any(r => (r.StartDate <= startDate && r.EndDate >= startDate) ||
                (r.StartDate >= startDate && r.StartDate <= endDate)));
                countDetails = await ItemsList.CountAsync();
            }
            ItemsList= ItemsList.Skip((page - 1 ?? 0) * pagesize).Take(pagesize);
            var ItemsListResult = await ItemsList.Where(c => c.IsDeleted == false).ToListAsync();
            var newItems = _mapper.Map<IEnumerable<CarReadDto>>(ItemsListResult);
            var result = new PageResult<CarReadDto>
            {
                Count = countDetails,
                PageIndex = page ?? 1,
                PageSize = 10,
                Items = newItems.ToList()

            };
            return result;
        }
        public async Task<bool> UpdateByIdAsync(int id, CarWriteDto carWriteDto)
        {
            var carFromDb = await GetCarByIdAsync(id);
            if(carFromDb is null)
            {
                return false;
            }
            carFromDb.AirConditioner = carWriteDto.AirConditioner;
            carFromDb.Blueotooth = carWriteDto.Blueotooth;
            carFromDb.CentralLocking = carWriteDto.CentralLocking;
            carFromDb.Door = carWriteDto.Door;
            carFromDb.GearShift = carWriteDto.GearShift;
            carFromDb.Mp = carWriteDto.Mp;
            carFromDb.Name = carWriteDto.Name;
            carFromDb.NavigationSystem = carWriteDto.NavigationSystem;
            carFromDb.ParkingSensors = carWriteDto.ParkingSensors;
            carFromDb.Seat = carWriteDto.Seat;
            return await _context.SaveChangesAsync() >= 0;

        }
    }
}
