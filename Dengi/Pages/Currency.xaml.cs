using System.Windows;
using System.Windows.Controls;
using Dengi.Core.DB;

namespace Dengi.Pages;

public partial class Currency : Page
{
    public Currency()
    {
        InitializeComponent();
        DataContext = MainWindow.WindowViewModel.CurrencyViewModel;
    }


    private void Currency_OnLoaded(object sender, RoutedEventArgs e)
    {
        UserCurrentCurrencyComboBox.SelectedItem = MainWindow.WindowViewModel.CurrencyViewModel.GetCurrencyList[0];
        ConvertedCurrencyComboBox.SelectedItem = MainWindow.WindowViewModel.CurrencyViewModel.GetCurrencyList[1];

        MainWindow.WindowViewModel.CurrencyViewModel.InitTable();

        UserCurrentCurrencyComboBox.SelectionChanged += UserCurrentCurrencyComboBox_OnSelectionChanged;
        ConvertedCurrencyComboBox.SelectionChanged += ConvertedCurrencyComboBox_OnSelectionChanged;
    }


    private void UserCurrencyAmmountTextBox_OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
    {
        var convertedCurrencyAmmount = CurrencyConverter.ConvertCurrency(
            (DB.Entities.Currency)UserCurrentCurrencyComboBox.SelectedItem,
            (DB.Entities.Currency)ConvertedCurrencyComboBox.SelectedItem,
            float.Parse(UserCurrencyAmmountTextBox.Text));
        ConvertedCurrencyAmmountTextBox.Text = convertedCurrencyAmmount.ToString();
    }

    private void ConvertedCurrencyAmmountTextBox_OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
    {
        var convertedCurrencyAmmount = CurrencyConverter.ConvertCurrency(
            (DB.Entities.Currency)ConvertedCurrencyComboBox.SelectedItem,
            (DB.Entities.Currency)UserCurrentCurrencyComboBox.SelectedItem,
            float.Parse(ConvertedCurrencyAmmountTextBox.Text));
        UserCurrencyAmmountTextBox.Text = convertedCurrencyAmmount.ToString();
    }

    private void ConvertedCurrencyComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var convertedCurrencyAmmount = CurrencyConverter.ConvertCurrency(
            (DB.Entities.Currency)ConvertedCurrencyComboBox.SelectedItem,
            (DB.Entities.Currency)UserCurrentCurrencyComboBox.SelectedItem,
            float.Parse(ConvertedCurrencyAmmountTextBox.Text));
        UserCurrencyAmmountTextBox.Text = convertedCurrencyAmmount.ToString();
    }

    private void UserCurrentCurrencyComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var convertedCurrencyAmmount = CurrencyConverter.ConvertCurrency(
            (DB.Entities.Currency)UserCurrentCurrencyComboBox.SelectedItem,
            (DB.Entities.Currency)ConvertedCurrencyComboBox.SelectedItem,
            float.Parse(UserCurrencyAmmountTextBox.Text));
        ConvertedCurrencyAmmountTextBox.Text = convertedCurrencyAmmount.ToString();
    }
}