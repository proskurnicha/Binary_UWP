using Binary_UWP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Binary_UWP.Services
{
    public class FlightService
    {
        private static List<Flight> Flights;

        public async Task<List<Flight>> GetFlights()
        {
            if (Flights == null)
            {
                string path = @"http://localhost:54956/api/Flights";
                string responseBody;
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(path);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                Flights = JsonConvert.DeserializeObject<List<Flight>>(responseBody);
            }
            return Flights;
        }
    }
}
