using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  GearShift { get; set; }
        public int Door { get; set; }
        public int Seat { get; set; }
        public bool Blueotooth { get; set; }
        public bool Mp { get; set; }
        public bool NavigationSystem { get; set; }
        public bool ParkingSensors { get; set; }
        public bool CentralLocking { get; set; }
        public bool AirConditioner { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public string Photo { get; set; }
        public int PricePerDay { get; set; }


    }
}
