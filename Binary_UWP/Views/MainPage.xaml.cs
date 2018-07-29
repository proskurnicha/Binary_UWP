using Binary_UWP;
using Binary_UWP.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HamburgerMenuApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // по умолчанию открываем страницу home.xaml
            myFrame.Navigate(typeof(FlightView));
            TitleTextBlock.Text = "Flights";
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (aircrafts.IsSelected)
            {
                myFrame.Navigate(typeof(AircraftView));
                TitleTextBlock.Text = "Aircrafts";
            }
            else if (flights.IsSelected)
            {
                myFrame.Navigate(typeof(FlightView));
                TitleTextBlock.Text = "Flights";
            }
            else if (crews.IsSelected)
            {
                myFrame.Navigate(typeof(CrewView));
                TitleTextBlock.Text = "Crews";
            }
            else if (departures.IsSelected)
            {
                myFrame.Navigate(typeof(DepartureView));
                TitleTextBlock.Text = "Departures";
            }
            else if (pilots.IsSelected)
            {
                myFrame.Navigate(typeof(PilotView));
                TitleTextBlock.Text = "Pilots";
            }
            else if (stewardess.IsSelected)
            {
                myFrame.Navigate(typeof(StewardessView));
                TitleTextBlock.Text = "Stewardesses";
            }
            else if (tickets.IsSelected)
            {
                myFrame.Navigate(typeof(TicketView));
                TitleTextBlock.Text = "Tickets";
            }
            else if (typesaircraft.IsSelected)
            {
                myFrame.Navigate(typeof(TypeAircraftView));
                TitleTextBlock.Text = "Types Aircraft";
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }
    }
}