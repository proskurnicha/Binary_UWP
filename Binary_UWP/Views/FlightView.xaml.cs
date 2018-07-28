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
        }

        public FlightViewModel ViewModel { get; set; }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(AcademyView), e.OriginalSource);
        }
    }
}