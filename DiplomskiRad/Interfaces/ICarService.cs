using DiplomskiRad.DTOS;
using DiplomskiRad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task<bool> UpdateByIdAsync(int id, CarWriteDto carWriteDto);
        Task<bool> AddCarAsync(Car car);
        Task<bool> DeleteCarById(int id);
        Task<PageResult<CarReadDto>> GetCars(int? page, DateTime? startDate, DateTime? endDate, int pagesize = 6);

    }
}
