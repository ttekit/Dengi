using System.Windows;
using System.Windows.Controls;
using Dengi.ViewModels;

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

        var selectedItem = TreeView_Categories.SelectedItem.ToString();

        MessageBox.Show(selectedItem);
    }

    private void ContextMenuItem_Edit_Click(object sender, RoutedEventArgs e)
    {
        if (TreeView_Categories.SelectedItem == null) return;

        var selectedItem = TreeView_Categories.SelectedItem.ToString();
    }

    private void ContextMenuItem_Delete_Click(object sender, RoutedEventArgs e)
    {
        if (TreeView_Categories.SelectedItem == null) return;

        var selectedItem = TreeView_Categories.SelectedItem.ToString();
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
            CategoryPageViewModel.DBContext.UpdateCategory(parentCategory);
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
        TreeView_Categories.ItemsSource = ((CategoryPageViewModel)DataContext).GetCategoriesThree;
    }
}