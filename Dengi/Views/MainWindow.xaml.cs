using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Dengi.Core;
using Dengi.Pages;
using Dengi.ViewModels;

namespace Dengi;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public static MainWindowViewModel WindowViewModel { get; private set; }

    private Navigation _navigation;
    private List<Page> _pages;

    public MainWindow()
    {
        WindowViewModel = new MainWindowViewModel();
        InitializeComponent();
    }

    
    private void MenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "https://www.youtube.com/watch?v=P1EO_IHAXrI",
            UseShellExecute = true
        });
    }
}