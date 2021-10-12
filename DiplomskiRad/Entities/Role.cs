using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
