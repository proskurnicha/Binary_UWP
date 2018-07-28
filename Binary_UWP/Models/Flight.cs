using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_UWP.Models
{
    public class Flight
    {
        public int Id { get; set; }

        public string DeparturePoint { get; set; }

        public TimeSpan DepartureTime { get; set; }

        public string ArrivalPoint { get; set; }

        public TimeSpan ArrivalTime { get; set; }

        public List<Ticket> Tickets { get; set; }

        public string Way => $"{DeparturePoint} - {ArrivalPoint}";
    }
}
