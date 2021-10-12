using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.DTOS
{
    public class ReservationReadDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int CarId { get; set; }
        public string CustomerName { get; set; }
        public string CarName { get; set; }
        public int DateRange { get; set; }
        public int PricePerDay { get; set; }
        public int Total { get; set; }


    }
}
