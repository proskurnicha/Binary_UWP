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
    public class FlightViewModel : BaseViewModel
    {
        private FlightService flightService;

        public FlightViewModel()
        {
            Title = "Flight";
            flightService = new FlightService();
            SearchFilter = "";
            Flights = new ObservableCollection<Flight>();
            Flight = new Flight();
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

        public ObservableCollection<Flight> Flights { get; private set; }

        public Flight Flight { get; set; }

        public async Task Search()
        {
            Flights.Clear();

            List<Flight> tempFlights = await flightService.GetAll();
            foreach (var item in tempFlights)
            {
                Flights.Add(item);
            }
        }

        public async Task Create()
        {
            Flight  flight = await flightService.Create(Flight);
            Flight = new Flight();

            List<Flight> tempFlights = await flightService.GetAll();
            Flights = new ObservableCollection<Flight>();
            foreach (var item in tempFlights)
            {
                Flights.Add(item);
            }
        }

        public async Task Update()
        {
            Flight flightUpdated = await flightService.Update(Flight, Flight.Id);
            Flight = new Flight();

            List<Flight> tempFlights = await flightService.GetAll();
            Flights = new ObservableCollection<Flight>();
            foreach (var fl in tempFlights)
            {
                Flights.Add(fl);
            }
        }

        public void CreateClicked()
        {
            Flight = new Flight();
            NotifyPropertyChanged(() => Flight);
        }

        public async Task Delete()
        {
            await flightService.Delete(Flight.Id);
            Flight = new Flight();
            NotifyPropertyChanged(() => Flight);
            List<Flight> tempFlights = await flightService.GetAll();
            Flights = new ObservableCollection<Flight>();
            foreach (var fl in tempFlights)
            {
                Flights.Add(fl);
            }
        }
    }
}
