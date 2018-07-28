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
    public class TypeAircraftService
    {
        private static TypeAircraft TypeAircraft;

        private static List<TypeAircraft> TypeAircrafts;

        private string api = App.Api + "TypeAircrafts";

        public async Task<List<TypeAircraft>> GetAll()
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            TypeAircrafts = JsonConvert.DeserializeObject<List<TypeAircraft>>(responseBody);

            return TypeAircrafts;
        }

        public async Task<TypeAircraft> GetById(int id)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{api}/{id}");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            TypeAircraft = JsonConvert.DeserializeObject<TypeAircraft>(responseBody);
            return TypeAircraft;
        }

        public async Task<TypeAircraft> Create(TypeAircraft TypeAircraft)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(TypeAircraft), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(api, stringContent);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            TypeAircraft = JsonConvert.DeserializeObject<TypeAircraft>(responseBody);
            return TypeAircraft;
        }

        public async Task<TypeAircraft> Update(TypeAircraft TypeAircraft, int id)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(TypeAircraft), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{api}/{id}", stringContent);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            TypeAircraft = JsonConvert.DeserializeObject<TypeAircraft>(responseBody);
            return TypeAircraft;
        }

        public async Task Delete(int id)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{api}/{id}");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
