using System.Windows;
using System.Windows.Controls;
using Dengi.ViewModels;
using Dengi.Views;

namespace Dengi.Pages;

public partial class Category : Page
{
    private Category selectedCategory;

    public Category()
    {
        InitializeComponent();
        DataContext = MainWindow.WindowViewModel.CategoryPageViewModel;
    }

    private void ContextMenuItem_Add_Click(object sender, RoutedEventArgs e)
    {
        if (TreeView_Categories.SelectedItem == null) return;
        if (TreeView_Categories.SelectedItem is not DB.Entities.Category) return;

        DB.Entities.Category selectedItem = (DB.Entities.Category)(TreeView_Categories.SelectedItem);
        AddItemDialog dialog = new AddItemDialog();
        dialog.ShowDialog();
        if (dialog.Result != null)
        {
            MainWindow.WindowViewModel.CategoryPageViewModel.AddCategory(new DB.Entities.Category()
            {
                Name = dialog.Result,
                ParentId = selectedItem.Id
            });
            Refresh();
        }
    }

    private void ContextMenuItem_Edit_Click(object sender, RoutedEventArgs e)
    {
        if (TreeView_Categories.SelectedItem == null) return;
        if (TreeView_Categories.SelectedItem is not DB.Entities.Category) return;

        DB.Entities.Category selectedItem = (DB.Entities.Category)(TreeView_Categories.SelectedItem);
        AddItemDialog dialog = new AddItemDialog();
        dialog.ShowDialog();
        if (dialog.Result != null)
        {
            selectedItem.Name = dialog.Result;
            MainWindow.WindowViewModel.CategoryPageViewModel.UpdateCategory(selectedItem); 
            Refresh();
        }
    }

    private void ContextMenuItem_Delete_Click(object sender, RoutedEventArgs e)
    {
        if (TreeView_Categories.SelectedItem == null) return;

        DB.Entities.Category selectedItem = (DB.Entities.Category)(TreeView_Categories.SelectedItem);
        MainWindow.WindowViewModel.CategoryPageViewModel.DeleteCategory(selectedItem);
        Refresh();

    }


    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        ComboBox_Categories.SelectedItem = null;
        TextBox_Category.Text = "";
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (ComboBox_Categories.SelectedItem != null &&
            TextBox_Category.Text != ((DB.Entities.Category)ComboBox_Categories.SelectedItem).Name)
        {
            DB.Entities.Category parentCategory = (DB.Entities.Category)ComboBox_Categories.SelectedItem;
            string text = TextBox_Category.Text;
            parentCategory.Name = text;
            MainWindow.WindowViewModel.CategoryPageViewModel.UpdateCategory(parentCategory);
            Refresh();
        }
    }

    private void ComboBox_Categories_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBox_Category.Text = ((DB.Entities.Category)comboBox.SelectedItem).Name;
        }
    }

    private void Refresh()
    {
        TreeView_Categories.ItemsSource = MainWindow.WindowViewModel.CategoryPageViewModel.GetCategoriesThree;
        TreeView_Categories.Items.Refresh();
        TreeView_Categories.UpdateLayout();
    }

    private void Category_OnLoaded(object sender, RoutedEventArgs e)
    {
        Refresh();
    }
}