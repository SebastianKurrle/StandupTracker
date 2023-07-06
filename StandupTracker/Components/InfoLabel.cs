using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StandupTracker.Components;

public class InfoLabel : IComponent
{
    public string Name { get; set; }
    public Label UIElement { get; set; }

    public InfoLabel(string content)
    {
        Name = "";

        UIElement = new();

        UIElement.Content = content;

        Design();
    }

    public void Design()
    {
        UIElement.FontSize = 15;
        UIElement.Foreground = Brushes.LightGreen;
        UIElement.HorizontalAlignment = HorizontalAlignment.Center;
    }
}
