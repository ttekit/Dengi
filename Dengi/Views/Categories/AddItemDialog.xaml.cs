using System.Windows;

namespace Dengi.Views;

public partial class AddItemDialog : Window
{
    public AddItemDialog()
    {
        InitializeComponent();
    }

    public string Result { get; private set; }

    private void SubmitButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (DataTextBox.Text != null)
        {
            Result = DataTextBox.Text;
            Close();
        }
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}