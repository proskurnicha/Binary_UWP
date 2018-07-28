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

        public async void Search()
        {
            Flights.Clear();
            List<Flight> tempFlights = await flightService.GetFlights();
            //if (string.IsNullOrWhiteSpace(SearchFilter))
            //{
                foreach (var student in tempFlights)
                {
                    Flights.Add(student);
                }
            //}
            //else
            //{
            //    foreach (var student in _academy.GetByStudentName(SearchFilter))
            //    {
            //        Students.Add(student);
            //    }
            //    foreach (var student in _academy.GetByStudentCity(SearchFilter))
            //    {
            //        Students.Add(student);
            //    }
            //}
        }
    }
}
