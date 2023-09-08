using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Dengi.Core;

public class Navigation
{
    private readonly List<NavigationButton> _buttons;
    private readonly Frame _container;
    private ToggleButton _lastActivatedButton;

    public Navigation(Frame container)
    {
        _container = container;
        _buttons = new List<NavigationButton>();
    }

    public void AddButton(ToggleButton button, Page page)
    {
        button.Checked += ButtonOnCheckedDisableAnother;
        _buttons.Add(new NavigationButton(_container, button, page));
    }

    private void ButtonOnCheckedDisableAnother(object sender, RoutedEventArgs e)
    {
        if (sender is not ToggleButton) return;
        if (_lastActivatedButton != null) _lastActivatedButton.IsChecked = false;
        _lastActivatedButton = (ToggleButton)sender;
    }
}