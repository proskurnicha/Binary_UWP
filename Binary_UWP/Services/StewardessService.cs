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
    public class StewardessService
    {
        private static Stewardess Stewardess;

        private static List<Stewardess> Stewardesss;

        private string api = App.Api + "Stewardesses";

        public async Task<List<Stewardess>> GetAll()
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Stewardesss = JsonConvert.DeserializeObject<List<Stewardess>>(responseBody);

            return Stewardesss;
        }

        public async Task<Stewardess> GetById(int id)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{api}/{id}");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Stewardess = JsonConvert.DeserializeObject<Stewardess>(responseBody);
            return Stewardess;
        }

        public async Task<Stewardess> Create(Stewardess Stewardess)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(Stewardess), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(api, stringContent);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Stewardess = JsonConvert.DeserializeObject<Stewardess>(responseBody);
            return Stewardess;
        }

        public async Task<Stewardess> Update(Stewardess Stewardess, int id)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(Stewardess), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{api}/{id}", stringContent);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Stewardess = JsonConvert.DeserializeObject<Stewardess>(responseBody);
            return Stewardess;
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
