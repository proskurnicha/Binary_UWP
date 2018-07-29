using Binary_UWP.Models;
using Binary_UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Binary_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TypeAircraftView : Page
    {
        public TypeAircraftView()
        {
            this.InitializeComponent();
            ViewModel = new TypeAircraftViewModel();
            this.DataContext = new TypeAircraft();
        }

        public TypeAircraftViewModel ViewModel { get; set; }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            dialogBox.Hide(); // закрываем окно
        }

        void TypeAircraftList_ItemClick(object sender, ItemClickEventArgs e)
        {
            TypeAircraft selectedTypeAircraft = (TypeAircraft)e.ClickedItem;
            ViewModel.TypeAircraft = selectedTypeAircraft;
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
