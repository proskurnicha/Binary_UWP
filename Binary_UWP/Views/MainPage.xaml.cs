using Binary_UWP;
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
            TitleTextBlock.Text = "Главная";
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (academy.IsSelected)
            {
                myFrame.Navigate(typeof(AcademyView));
                TitleTextBlock.Text = "Academy";
            }
            else if (flights.IsSelected)
            {
                myFrame.Navigate(typeof(FlightView));
                TitleTextBlock.Text = "Flights";
            }
            else if (settings.IsSelected)
            {
                myFrame.Navigate(typeof(FlightView));
                TitleTextBlock.Text = "Other";
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }
    }
}