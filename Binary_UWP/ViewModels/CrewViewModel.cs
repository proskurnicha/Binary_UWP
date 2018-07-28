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

        public async void Search()
        {
            Crews.Clear();

            List<Crew> tempCrews = await CrewService.GetAll();
            foreach (var student in tempCrews)
            {
                Crews.Add(student);
            }
        }
    }
}
