using AutoMapper;
using DiplomskiRad.DTOS;
using DiplomskiRad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Car, CarReadDto>();
            CreateMap<Reservation, ReservationReadDto>();
            CreateMap<CarWriteDto, Car>();
            CreateMap<ReservationWriteDto, Reservation>();
            CreateMap<AppUser, UserDto>().ReverseMap();
           
        }
    }
}
