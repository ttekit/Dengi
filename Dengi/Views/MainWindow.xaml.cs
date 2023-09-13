using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Dengi.Core;
using Dengi.ViewModels;

namespace Dengi;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Navigation _navigation;
    private List<Page> _pages;

    public MainWindow()
    {
        WindowViewModel = new MainWindowViewModel();
        InitializeComponent();
    }

    public static MainWindowViewModel WindowViewModel { get; private set; }
}