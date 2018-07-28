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

        public async void Search()
        {
            Stewardesss.Clear();

            List<Stewardess> tempStewardesss = await StewardessService.GetAll();
            foreach (var student in tempStewardesss)
            {
                Stewardesss.Add(student);
            }
        }
    }
}
