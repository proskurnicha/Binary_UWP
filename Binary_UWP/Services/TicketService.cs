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
    public class TicketService
    {
        private static Ticket Ticket;

        private static List<Ticket> Tickets;

        private string api = App.Api + "Tickets";

        public async Task<List<Ticket>> GetAll()
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Tickets = JsonConvert.DeserializeObject<List<Ticket>>(responseBody);

            return Tickets;
        }

        public async Task<Ticket> GetById(int id)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{api}/{id}");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Ticket = JsonConvert.DeserializeObject<Ticket>(responseBody);
            return Ticket;
        }

        public async Task<Ticket> Create(Ticket Ticket)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(Ticket), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(api, stringContent);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Ticket = JsonConvert.DeserializeObject<Ticket>(responseBody);
            return Ticket;
        }

        public async Task<Ticket> Update(Ticket Ticket, int id)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(Ticket), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{api}/{id}", stringContent);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            Ticket = JsonConvert.DeserializeObject<Ticket>(responseBody);
            return Ticket;
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
