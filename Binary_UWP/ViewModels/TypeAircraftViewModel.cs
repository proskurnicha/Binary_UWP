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
    public class TypeAircraftViewModel : BaseViewModel
    {
        private TypeAircraftService TypeAircraftService;

        public TypeAircraftViewModel()
        {
            Title = "TypeAircraft";
            TypeAircraftService = new TypeAircraftService();
            SearchFilter = "";
            TypeAircrafts = new ObservableCollection<TypeAircraft>();
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

        public ObservableCollection<TypeAircraft> TypeAircrafts { get; private set; }

        public async void Search()
        {
            TypeAircrafts.Clear();

            List<TypeAircraft> tempTypeAircrafts = await TypeAircraftService.GetAll();
            foreach (var student in tempTypeAircrafts)
            {
                TypeAircrafts.Add(student);
            }
        }
    }
}
