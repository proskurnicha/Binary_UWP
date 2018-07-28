using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_UWP.Models
{
    public class Aircraft
    {
        public int Id { get; set; }

        public string AircraftName { get; set; }
        
        public int TypeAircraftId { get; set; }

        public DateTime DateRelease { get; set; }

        public TimeSpan Lifetime { get; set; }
    }
}
