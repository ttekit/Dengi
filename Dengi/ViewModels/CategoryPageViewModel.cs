using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Dengi.DB.Entities;

namespace Dengi.ViewModels
{
    public class CategoryPageViewModel:ViewFinancesModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public List<Category>Categories
        {
            get { return DBContext.Categories.ToList(); }
        }
    }
}
