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
    public class AircraftService
    {
        private static Aircraft Aircraft;

        private static List<Aircraft> Aircrafts;

        private string api = App.Api + "Aircrafts";

        public async Task<List<Aircraft>> GetAll()
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Aircrafts = JsonConvert.DeserializeObject<List<Aircraft>>(responseBody);

            return Aircrafts;
        }

        public async Task<Aircraft> GetById(int id)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{api}/{id}");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Aircraft = JsonConvert.DeserializeObject<Aircraft>(responseBody);
            return Aircraft;
        }

        public async Task<Aircraft> Create(Aircraft Aircraft)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(Aircraft), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(api, stringContent);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Aircraft = JsonConvert.DeserializeObject<Aircraft>(responseBody);
            return Aircraft;
        }

        public async Task<Aircraft> Update(Aircraft Aircraft, int id)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(Aircraft), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{api}/{id}", stringContent);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Aircraft = JsonConvert.DeserializeObject<Aircraft>(responseBody);
            return Aircraft;
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
