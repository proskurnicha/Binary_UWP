using Binary_UWP.Models;
using Binary_UWP.ViewModels;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Binary_UWP
{
    public sealed partial class FlightView : Page
    {
        public FlightView()
        {
            this.InitializeComponent();
            ViewModel = new FlightViewModel();
            this.DataContext = new Flight();
        }

        public FlightViewModel ViewModel { get; set; }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            dialogBox.Hide(); // закрываем окно
        }

        void FlightList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Flight selectedFlight = (Flight)e.ClickedItem;
            ViewModel.Flight = selectedFlight;
        }

        private void ListTapped(object sender, TappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout(sender as FrameworkElement);
        }

        void SaveEntity(object sender, RoutedEventArgs e)
        {
           ViewModel.Update();
        }

        void DeleteEntity(object sender, RoutedEventArgs e)
        {
            ViewModel.Delete();
        }
    }
}