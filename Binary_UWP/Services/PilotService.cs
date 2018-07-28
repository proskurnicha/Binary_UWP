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
    public class PilotService
    {
        private static Pilot Pilot;

        private static List<Pilot> Pilots;

        private string api = App.Api + "Pilots";

        public async Task<List<Pilot>> GetAll()
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Pilots = JsonConvert.DeserializeObject<List<Pilot>>(responseBody);

            return Pilots;
        }

        public async Task<Pilot> GetById(int id)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{api}/{id}");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Pilot = JsonConvert.DeserializeObject<Pilot>(responseBody);
            return Pilot;
        }

        public async Task<Pilot> Create(Pilot Pilot)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(Pilot), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(api, stringContent);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Pilot = JsonConvert.DeserializeObject<Pilot>(responseBody);
            return Pilot;
        }

        public async Task<Pilot> Update(Pilot Pilot, int id)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(Pilot), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{api}/{id}", stringContent);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Pilot = JsonConvert.DeserializeObject<Pilot>(responseBody);
            return Pilot;
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
