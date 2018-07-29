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
    public class StewardessViewModel : BaseViewModel
    {
        private StewardessService StewardessService;

        public StewardessViewModel()
        {
            Title = "Stewardess";
            StewardessService = new StewardessService();
            SearchFilter = "";
            Stewardesss = new ObservableCollection<Stewardess>();
            Stewardess = new Stewardess();
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

        public ObservableCollection<Stewardess> Stewardesss { get; private set; }

        public Stewardess Stewardess { get; set; }

        public async Task Search()
        {
            Stewardesss.Clear();

            List<Stewardess> tempStewardesss = await StewardessService.GetAll();
            foreach (var item in tempStewardesss)
            {
                Stewardesss.Add(item);
            }
        }

        public async Task Create()
        {
            Stewardess Stewardess = await StewardessService.Create(this.Stewardess);
            Stewardess = new Stewardess();

            List<Stewardess> tempStewardesss = await StewardessService.GetAll();
            Stewardesss = new ObservableCollection<Stewardess>();
            foreach (var item in tempStewardesss)
            {
                Stewardesss.Add(item);
            }
            NotifyPropertyChanged(() => Stewardesss);

        }

        public async Task Update()
        {
            Stewardess StewardessUpdated = await StewardessService.Update(Stewardess, Stewardess.Id);
            Stewardess = new Stewardess();

            List<Stewardess> tempStewardesss = await StewardessService.GetAll();
            Stewardesss = new ObservableCollection<Stewardess>();
            foreach (var fl in tempStewardesss)
            {
                Stewardesss.Add(fl);
            }
            NotifyPropertyChanged(() => Stewardesss);
        }

        public void CreateClicked()
        {
            Stewardess = new Stewardess();
            NotifyPropertyChanged(() => Stewardess);
        }

        public async Task Delete()
        {
            await StewardessService.Delete(Stewardess.Id);
            Stewardess = new Stewardess();
            NotifyPropertyChanged(() => Stewardess);
            List<Stewardess> tempStewardesss = await StewardessService.GetAll();
            Stewardesss = new ObservableCollection<Stewardess>();
            foreach (var fl in tempStewardesss)
            {
                Stewardesss.Add(fl);
            }
            NotifyPropertyChanged(() => Stewardesss);

        }
    }
}
