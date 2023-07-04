using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StandupTracker.Components;

class ErrorLabel : IComponent
{
    public string Name { get; set; }
    public Label UIElement { get; set; }

    public ErrorLabel(string content)
    {
        Name = "";

        UIElement = new();

        UIElement.Content = content;

        Design();
    }

    public void Design()
    {
        UIElement.FontSize = 15;
        UIElement.HorizontalAlignment = HorizontalAlignment.Center;
        UIElement.Foreground = Brushes.DarkRed;
    }
}
