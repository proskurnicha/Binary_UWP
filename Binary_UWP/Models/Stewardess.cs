using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_UWP.Models
{
    public class Stewardess
    {
        public int Id { get; set; }

        public int CrewId { get; set; }

        public DateTime DateBirth { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
