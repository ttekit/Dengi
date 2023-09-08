using System;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Dengi.Core;

public class NavigationButton
{
    private ToggleButton _button;
    private Page _page;

    public NavigationButton(Frame container, ToggleButton button, Page content)
    {
        _button = button;
        _page = content;

        _button.Checked += (sender, args) => container.Navigate(content);
    }

    public Page Page
    {
        get => _page;
        set => _page = value ?? throw new ArgumentNullException(nameof(value));
    }

    public ToggleButton Button
    {
        get => _button;
        set => _button = value ?? throw new ArgumentNullException(nameof(value));
    }
}