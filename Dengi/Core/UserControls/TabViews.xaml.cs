using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;
using Dengi.Pages;

namespace Dengi.Core.UserControls;

public partial class TabViews : UserControl
{
    public List<KeyValuePair<ToggleButton, Page>> Pages = new List<KeyValuePair<ToggleButton, Page>>();

    public TabViews()
    {
        InitializeComponent();

        MainContent_Page.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        Pages.Add(new KeyValuePair<ToggleButton, Page>(Category_ToggleButton, new Category()));
        Pages.Add(new KeyValuePair<ToggleButton, Page>(Home_ToggleButton, new Home()));
        Pages.Add(new KeyValuePair<ToggleButton, Page>(Invoices_ToggleButton, new Invoices()));
        Pages.Add(new KeyValuePair<ToggleButton, Page>(Reports_ToggleButton, new Reports()));
        Pages.Add(new KeyValuePair<ToggleButton, Page>(Sheduler_ToggleButton, new Sheduler()));

        MainContent_Page.Navigate(Pages.First().Value);
        Pages.First().Key.IsChecked = true;
    }

    private void ToggleButton_Main_Click(object sender, RoutedEventArgs e)
    {
        foreach (var item in Controls_ToolBar.Items)
            if (item is ToggleButton)
            {
                ((ToggleButton)item).IsChecked = false;
                if (sender == item)
                {
                    ((ToggleButton)item).IsChecked = true;
                    foreach (var onePage in Pages)
                        if (onePage.Key == sender)
                        {
                            MainContent_Page.Navigate(onePage.Value);
                        }
                }
            }
    }
}