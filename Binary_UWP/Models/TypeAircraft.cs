using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_UWP.Models
{
    public class TypeAircraft
    {
        public int Id { get; set; }

        public AircraftModel AircraftModel { get; set; }

        public int NumberPlaces { get; set; }

        public int CarryingCapacity { get; set; }
    }
}
