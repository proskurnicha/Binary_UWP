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
    public class PilotViewModel : BaseViewModel
    {
        private PilotService PilotService;

        public PilotViewModel()
        {
            Title = "Pilot";
            PilotService = new PilotService();
            SearchFilter = "";
            Pilots = new ObservableCollection<Pilot>();
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

        public ObservableCollection<Pilot> Pilots { get; private set; }

        public async void Search()
        {
            Pilots.Clear();

            List<Pilot> tempPilots = await PilotService.GetAll();
            foreach (var student in tempPilots)
            {
                Pilots.Add(student);
            }
        }
    }
}
