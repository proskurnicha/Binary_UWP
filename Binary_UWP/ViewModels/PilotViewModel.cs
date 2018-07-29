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
            Pilot = new Pilot();
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

        public Pilot Pilot { get; set; }

        public async Task Search()
        {
            Pilots.Clear();

            List<Pilot> tempPilots = await PilotService.GetAll();
            foreach (var item in tempPilots)
            {
                Pilots.Add(item);
            }
        }

        public async Task Create()
        {
            Pilot Pilot = await PilotService.Create(this.Pilot);
            Pilot = new Pilot();

            List<Pilot> tempPilots = await PilotService.GetAll();
            Pilots = new ObservableCollection<Pilot>();
            foreach (var item in tempPilots)
            {
                Pilots.Add(item);
            }
        }

        public async Task Update()
        {
            Pilot PilotUpdated = await PilotService.Update(Pilot, Pilot.Id);
            Pilot = new Pilot();

            List<Pilot> tempPilots = await PilotService.GetAll();
            Pilots = new ObservableCollection<Pilot>();
            foreach (var fl in tempPilots)
            {
                Pilots.Add(fl);
            }
        }

        public void CreateClicked()
        {
            Pilot = new Pilot();
            NotifyPropertyChanged(() => Pilot);
        }

        public async Task Delete()
        {
            await PilotService.Delete(Pilot.Id);
            Pilot = new Pilot();
            NotifyPropertyChanged(() => Pilot);
            List<Pilot> tempPilots = await PilotService.GetAll();
            Pilots = new ObservableCollection<Pilot>();
            foreach (var fl in tempPilots)
            {
                Pilots.Add(fl);
            }
        }
    }
}
