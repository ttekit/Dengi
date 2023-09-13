using System.ComponentModel;

namespace Dengi.ViewModels;

public class MainWindowViewModel : ViewFinancesModel, INotifyPropertyChanged
{
    public CategoryPageViewModel CategoryPageViewModel;
    public CurrencyViewModel CurrencyViewModel;

    public MainWindowViewModel()
    {
        CategoryPageViewModel = new CategoryPageViewModel();
        CurrencyViewModel = new CurrencyViewModel();
    }

    public event PropertyChangedEventHandler PropertyChanged;
}