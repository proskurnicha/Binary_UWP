using Binary_UWP.Models;
using Binary_UWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            dialogBox.Hide(); // закрываем окно
        }
    }
}