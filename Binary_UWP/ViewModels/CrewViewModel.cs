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
    public class CrewViewModel : BaseViewModel
    {
        private CrewService CrewService;

        public CrewViewModel()
        {
            Title = "Crew";
            CrewService = new CrewService();
            SearchFilter = "";
            Crews = new ObservableCollection<Crew>();
            Crew = new Crew();
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

        public ObservableCollection<Crew> Crews { get; private set; }

        public Crew Crew { get; set; }

        public async Task Search()
        {
            Crews.Clear();

            List<Crew> tempCrews = await CrewService.GetAll();
            foreach (var item in tempCrews)
            {
                Crews.Add(item);
            }
        }

        public async Task Create()
        {
            Crew Crew = await CrewService.Create(this.Crew);
            Crew = new Crew();

            List<Crew> tempCrews = await CrewService.GetAll();
            Crews = new ObservableCollection<Crew>();
            foreach (var item in tempCrews)
            {
                Crews.Add(item);
            }
            NotifyPropertyChanged(() => Crews);

        }

        public async Task Update()
        {
            Crew CrewUpdated = await CrewService.Update(Crew, Crew.Id);
            Crew = new Crew();

            List<Crew> tempCrews = await CrewService.GetAll();
            Crews = new ObservableCollection<Crew>();
            foreach (var fl in tempCrews)
            {
                Crews.Add(fl);
            }
            NotifyPropertyChanged(() => Crews);
        }

        public void CreateClicked()
        {
            Crew = new Crew();
            NotifyPropertyChanged(() => Crew);
        }

        public async Task Delete()
        {
            await CrewService.Delete(Crew.Id);
            Crew = new Crew();
            NotifyPropertyChanged(() => Crew);
            List<Crew> tempCrews = await CrewService.GetAll();
            Crews = new ObservableCollection<Crew>();
            foreach (var fl in tempCrews)
            {
                Crews.Add(fl);
            }
            NotifyPropertyChanged(() => Crews);

        }
    }
}
