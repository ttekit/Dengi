using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Dengi.Core;
using Dengi.Pages;


namespace Dengi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Page> _pages;
        private Core.Navigation _navigation;

        public MainWindow()
        {
            InitializeComponent();
            InitPages();
        }

        private void InitPages()
        {
            _navigation = new Navigation(MainContent_Page);
            _navigation.AddButton(Reports_ToggleButton, new Reports());
            _navigation.AddButton(Invoices_ToggleButton, new Invoices());
            _navigation.AddButton(Sheduler_ToggleButton, new Sheduler());
            MainContent_Page.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.youtube.com/watch?v=P1EO_IHAXrI",
                UseShellExecute = true
            });
        }
    }
}