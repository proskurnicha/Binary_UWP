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
            Departure = new Departure();
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

        public Departure Departure { get; set; }

        public async Task Search()
        {
            Departures.Clear();

            List<Departure> tempDepartures = await DepartureService.GetAll();
            foreach (var item in tempDepartures)
            {
                Departures.Add(item);
            }
        }

        public async Task Create()
        {
            Departure Departure = await DepartureService.Create(this.Departure);
            Departure = new Departure();

            List<Departure> tempDepartures = await DepartureService.GetAll();
            Departures = new ObservableCollection<Departure>();
            foreach (var item in tempDepartures)
            {
                Departures.Add(item);
            }
        }

        public async Task Update()
        {
            Departure DepartureUpdated = await DepartureService.Update(Departure, Departure.Id);
            Departure = new Departure();

            List<Departure> tempDepartures = await DepartureService.GetAll();
            Departures = new ObservableCollection<Departure>();
            foreach (var fl in tempDepartures)
            {
                Departures.Add(fl);
            }
        }

        public void CreateClicked()
        {
            Departure = new Departure();
            NotifyPropertyChanged(() => Departure);
        }

        public async Task Delete()
        {
            await DepartureService.Delete(Departure.Id);
            Departure = new Departure();
            NotifyPropertyChanged(() => Departure);
            List<Departure> tempDepartures = await DepartureService.GetAll();
            Departures = new ObservableCollection<Departure>();
            foreach (var fl in tempDepartures)
            {
                Departures.Add(fl);
            }
        }
    }
}
