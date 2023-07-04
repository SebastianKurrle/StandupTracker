using System.Windows;
using System.Windows.Controls;

namespace StandupTracker.Components;

public class HeadLineLabel : IComponent
{
    public string Name { get; set; }
    public Label UIElement { get; set; }

    public HeadLineLabel(string content)
    {
        Name = "";

        UIElement = new();

        UIElement.Content = content;

        Design();
    }

    public void Design()
    {
        UIElement.FontSize = 25;
        UIElement.FontWeight = FontWeights.Bold;
        UIElement.HorizontalAlignment = HorizontalAlignment.Center;
    }
}
