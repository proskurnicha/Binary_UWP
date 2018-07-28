using Binary_UWP.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Binary_UWP
{
    public sealed partial class AcademyView : Page
    {
        public AcademyView()
        {
            this.InitializeComponent();
            ViewModel = new AcademyViewModel();
        }

        public AcademyViewModel ViewModel { get; set; }
    }
}