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

        public async void Search()
        {
            Tickets.Clear();

            List<Ticket> tempTickets = await TicketService.GetAll();
            foreach (var student in tempTickets)
            {
                Tickets.Add(student);
            }
        }
    }
}
