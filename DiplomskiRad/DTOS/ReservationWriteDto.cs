using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.DTOS
{
    public class ReservationWriteDto
    {   [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public int CarId { get; set; }
    }
}
