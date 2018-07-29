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
    public class AircraftViewModel : BaseViewModel
    {
        private AircraftService AircraftService;

        public AircraftViewModel()
        {
            Title = "Aircraft";
            AircraftService = new AircraftService();
            SearchFilter = "";
            Aircrafts = new ObservableCollection<Aircraft>();
            Aircraft = new Aircraft();
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

        public ObservableCollection<Aircraft> Aircrafts { get; private set; }

        public Aircraft Aircraft { get; set; }

        public async Task Search()
        {
            Aircrafts.Clear();

            List<Aircraft> tempAircrafts = await AircraftService.GetAll();
            foreach (var item in tempAircrafts)
            {
                Aircrafts.Add(item);
            }
        }

        public async Task Create()
        {
            Aircraft Aircraft = await AircraftService.Create(this.Aircraft);
            Aircraft = new Aircraft();

            List<Aircraft> tempAircrafts = await AircraftService.GetAll();
            Aircrafts = new ObservableCollection<Aircraft>();
            foreach (var item in tempAircrafts)
            {
                Aircrafts.Add(item);
            }
            NotifyPropertyChanged(() => Aircrafts);

        }

        public async Task Update()
        {
            Aircraft AircraftUpdated = await AircraftService.Update(Aircraft, Aircraft.Id);
            Aircraft = new Aircraft();

            List<Aircraft> tempAircrafts = await AircraftService.GetAll();
            Aircrafts = new ObservableCollection<Aircraft>();
            foreach (var fl in tempAircrafts)
            {
                Aircrafts.Add(fl);
            }
            NotifyPropertyChanged(() => Aircrafts);

        }

        public void CreateClicked()
        {
            Aircraft = new Aircraft();
            NotifyPropertyChanged(() => Aircraft);
        }

        public async Task Delete()
        {
            await AircraftService.Delete(Aircraft.Id);
            Aircraft = new Aircraft();
            NotifyPropertyChanged(() => Aircraft);
            List<Aircraft> tempAircrafts = await AircraftService.GetAll();
            Aircrafts = new ObservableCollection<Aircraft>();
            foreach (var fl in tempAircrafts)
            {
                Aircrafts.Add(fl);
            }
            NotifyPropertyChanged(() => Aircrafts);

        }
    }
}
