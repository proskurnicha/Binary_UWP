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
    public class DepartureViewModel :BaseViewModel
    {
        private DepartureService DepartureService;

        public DepartureViewModel()
        {
            Title = "Departure";
            DepartureService = new DepartureService();
            SearchFilter = "";
            Departures = new ObservableCollection<Departure>();
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

        public ObservableCollection<Departure> Departures { get; private set; }

        public async void Search()
        {
            Departures.Clear();

            List<Departure> tempDepartures = await DepartureService.GetAll();
            foreach (var student in tempDepartures)
            {
                Departures.Add(student);
            }
        }
    }
}
