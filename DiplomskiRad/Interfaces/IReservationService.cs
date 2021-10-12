using DiplomskiRad.DTOS;
using DiplomskiRad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Interfaces
{
    public interface IReservationService
    {
        Task <bool>CreateReservation(Reservation reservation);
        Task<IEnumerable<ReservationReadDto>> GetAllReservationsAsync();
        Task<IEnumerable<ReservationReadDto>> GetAllReservationsUserAsync();
        Task<Reservation> GetReservationById(int id);
        Task<bool> DeleteReservationById(int id);



    }
}
