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

        public async void Search()
        {
            Aircrafts.Clear();

            List<Aircraft> tempAircrafts = await AircraftService.GetAll();
            foreach (var student in tempAircrafts)
            {
                Aircrafts.Add(student);
            }
        }
    }
}
