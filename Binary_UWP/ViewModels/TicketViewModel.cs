using Binary_UWP.Models;
using Binary_UWP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_UWP.ViewModels
{
    public class TicketViewModel : BaseViewModel
    {
        private TicketService TicketService;

        public TicketViewModel()
        {
            Title = "Ticket";
            TicketService = new TicketService();
            SearchFilter = "";
            Tickets = new ObservableCollection<Ticket>();
            Ticket = new Ticket();
            Search();
        }

        private string _searchFilter;
        public string SearchFilter
        {
            get { return _searchFilter; }
            set
            {
                _searchFilter = value;
                NotifyPropertyChanged(() => SearchFilter);
            }
        }

        public ObservableCollection<Ticket> Tickets { get; private set; }

        public Ticket Ticket { get; set; }

        public async Task Search()
        {
            Tickets.Clear();

            List<Ticket> tempTickets = await TicketService.GetAll();
            foreach (var item in tempTickets)
            {
                Tickets.Add(item);
            }
        }

        public async Task Create()
        {
            Ticket Ticket = await TicketService.Create(this.Ticket);
            Ticket = new Ticket();

            List<Ticket> tempTickets = await TicketService.GetAll();
            Tickets = new ObservableCollection<Ticket>();
            foreach (var item in tempTickets)
            {
                Tickets.Add(item);
            }
            NotifyPropertyChanged(() => Tickets);

        }

        public async Task Update()
        {
            Ticket TicketUpdated = await TicketService.Update(Ticket, Ticket.Id);
            Ticket = new Ticket();

            List<Ticket> tempTickets = await TicketService.GetAll();
            Tickets = new ObservableCollection<Ticket>();
            foreach (var fl in tempTickets)
            {
                Tickets.Add(fl);
            }
            NotifyPropertyChanged(() => Tickets);
        }

        public void CreateClicked()
        {
            Ticket = new Ticket();
            NotifyPropertyChanged(() => Ticket);
        }

        public async Task Delete()
        {
            await TicketService.Delete(Ticket.Id);
            Ticket = new Ticket();
            NotifyPropertyChanged(() => Ticket);
            List<Ticket> tempTickets = await TicketService.GetAll();
            Tickets = new ObservableCollection<Ticket>();
            foreach (var fl in tempTickets)
            {
                Tickets.Add(fl);
            }
            NotifyPropertyChanged(() => Tickets);
        }
    }
}
