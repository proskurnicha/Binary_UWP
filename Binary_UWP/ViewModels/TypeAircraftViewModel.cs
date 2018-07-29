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
            TypeAircraft = new TypeAircraft();
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

        public TypeAircraft TypeAircraft { get; set; }

        public async Task Search()
        {
            TypeAircrafts.Clear();

            List<TypeAircraft> tempTypeAircrafts = await TypeAircraftService.GetAll();
            foreach (var item in tempTypeAircrafts)
            {
                TypeAircrafts.Add(item);
            }

        }

        public async Task Create()
        {
            TypeAircraft TypeAircraft = await TypeAircraftService.Create(this.TypeAircraft);
            TypeAircraft = new TypeAircraft();

            List<TypeAircraft> tempTypeAircrafts = await TypeAircraftService.GetAll();
            TypeAircrafts = new ObservableCollection<TypeAircraft>();
            foreach (var item in tempTypeAircrafts)
            {
                TypeAircrafts.Add(item);
            }
            NotifyPropertyChanged(() => TypeAircrafts);

        }

        public async Task Update()
        {
            TypeAircraft TypeAircraftUpdated = await TypeAircraftService.Update(TypeAircraft, TypeAircraft.Id);
            TypeAircraft = new TypeAircraft();

            List<TypeAircraft> tempTypeAircrafts = await TypeAircraftService.GetAll();
            TypeAircrafts = new ObservableCollection<TypeAircraft>();
            foreach (var fl in tempTypeAircrafts)
            {
                TypeAircrafts.Add(fl);
            }
            NotifyPropertyChanged(() => TypeAircrafts);

        }

        public void CreateClicked()
        {
            TypeAircraft = new TypeAircraft();
            NotifyPropertyChanged(() => TypeAircraft);
        }

        public async Task Delete()
        {
            await TypeAircraftService.Delete(TypeAircraft.Id);
            TypeAircraft = new TypeAircraft();
            NotifyPropertyChanged(() => TypeAircraft);
            List<TypeAircraft> tempTypeAircrafts = await TypeAircraftService.GetAll();
            TypeAircrafts = new ObservableCollection<TypeAircraft>();
            foreach (var fl in tempTypeAircrafts)
            {
                TypeAircrafts.Add(fl);
            }
            NotifyPropertyChanged(() => TypeAircrafts);

        }
    }
}
