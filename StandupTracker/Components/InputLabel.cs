using System.Windows;
using System.Windows.Controls;

namespace StandupTracker.Components;

class InputLabel : IComponent
{
    public string Name { get; set; }
    public Label UIElement { get; set; }

    public InputLabel(string content)
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
    }
}
