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
    public class CrewService
    {
        private static Crew Crew;

        private static List<Crew> Crews;

        private string api = App.Api + "Crews";

        public async Task<List<Crew>> GetAll()
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Crews = JsonConvert.DeserializeObject<List<Crew>>(responseBody);

            return Crews;
        }

        public async Task<Crew> GetById(int id)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{api}/{id}");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Crew = JsonConvert.DeserializeObject<Crew>(responseBody);
            return Crew;
        }

        public async Task<Crew> Create(Crew Crew)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(Crew), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(api, stringContent);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Crew = JsonConvert.DeserializeObject<Crew>(responseBody);
            return Crew;
        }

        public async Task<Crew> Update(Crew Crew, int id)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(Crew), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{api}/{id}", stringContent);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Crew = JsonConvert.DeserializeObject<Crew>(responseBody);
            return Crew;
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
