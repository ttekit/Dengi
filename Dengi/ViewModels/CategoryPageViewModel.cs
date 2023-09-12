using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Dengi.DB.Entities;

namespace Dengi.ViewModels
{
    public class CategoryPageViewModel : ViewFinancesModel, INotifyPropertyChanged
    {
        public List<Category> Categories => DBContext.Categories.ToList();

        public List<Category> RootCategories
        {
            get
            {
                var originalList = DBContext.Categories.Where(c => c.ParentId == null).ToList();
                return originalList;
            }
        }

        public List<Category> GetCategoriesThree
        {
            get
            {
                List<Category> result = new List<Category>();
                foreach (var parent in RootCategories)
                {
                    result.Add(GetParentWithChildrens(parent));

                }

                return result;
            }
        }


        private Category GetParentWithChildrens(Category parent)
        {

            foreach (var child in Categories)
            {

                if (parent.Id == child.ParentId)
                {
                    if (child.SubCategories != null) GetParentWithChildrens(child);
                    if (!parent.SubCategories.Contains(child))
                    {
                        parent.SubCategories.Add(child);
                    }
                }
            }

            return parent;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public bool DeleteCategory(Category category)
        {
            if (category != null)
            {
                DBContext.Categories.Remove(category);
                return DBContext.SaveChanges() == 0;
            }

            return false;
        }

        public bool AddCategory(Category category)
        {
            if (category != null)
            {
                DBContext.Categories.Add(category);
                return DBContext.SaveChanges() == 1;
            }

            return false;
        }

        public bool UpdateCategory(Category category)
        {
            if (category != null)
            {
                DBContext.Categories.Update(category);

                return DBContext.SaveChanges() == 0;
            }

            return false;
        }
    }
}