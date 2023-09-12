using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Dengi.Core.UserControls;

public class NavigationToggleButton : ToggleButton
{
    public static readonly DependencyProperty LinkProperty =
        DependencyProperty.Register(nameof(Link), typeof(Uri), typeof(NavigationToggleButton),
            new PropertyMetadata(null));

    static NavigationToggleButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationToggleButton),
            new FrameworkPropertyMetadata(typeof(NavigationToggleButton)));
    }

    public Uri Link
    {
        get => (Uri)GetValue(LinkProperty);
        set => SetValue(LinkProperty, value);
    }
}