using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Dengi.DB.Entities;

namespace Dengi.ViewModels
{
    public class CategoryPageViewModel : ViewFinancesModel, INotifyPropertyChanged
    {
        private Category _selectedCategory;

        public Category SelectedCategory
        {
            get => _selectedCategory;

            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }


        public List<Category> Categories => DBContext.Categories.ToList();

        public List<Category> RootCategories
        {
            get { return DBContext.Categories.Where(c => c.ParentId == null).ToList(); }
        }

        public List<Category> GetCategoriesThree
        {
            get
            {
                foreach (var parent in RootCategories)
                foreach (var child in Categories)
                    if (parent.Id == child.ParentId)
                        parent.SubCategories.Add(child);
                return RootCategories.ToList();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}