using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_UWP.Models
{
    public class Departure
    {
        public int Id { get; set; }

        public int FlightId { get; set; }

        public DateTime DepartureTime { get; set; }

        public int CrewId { get; set; }

        public int AircraftId { get; set; }
    }
}
