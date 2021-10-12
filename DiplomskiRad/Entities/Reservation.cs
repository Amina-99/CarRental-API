using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public int DateRange { get; set; }
        public int Total { get; set; }
    }
}
