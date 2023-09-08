using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dengi.ViewModels
{
    public class MainWindowViewModel:ViewFinancesModel, INotifyPropertyChanged
    {
       public CategoryPageViewModel CategoryPageViewModel;

        public MainWindowViewModel()
        {
            CategoryPageViewModel = new CategoryPageViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
