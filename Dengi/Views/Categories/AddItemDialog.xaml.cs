using System.Windows;

namespace Dengi.Views;

public partial class AddItemDialog : Window
{
    public string Result { get; private set; }

    public AddItemDialog()
    {
        InitializeComponent();
    }

    private void SubmitButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (DataTextBox.Text != null)
        {
            Result = DataTextBox.Text;
            this.Close();
        }
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}