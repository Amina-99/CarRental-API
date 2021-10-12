using DiplomskiRad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.DTOS
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public int RolaId { get; set; }
    }
}
