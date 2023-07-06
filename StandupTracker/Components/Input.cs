using System.Windows;
using System.Windows.Controls;

namespace StandupTracker.Components;

class Input : IComponent
{
    public string Name { get; set; }
    public TextBox UIElement { get; set; }

    public Input(string name)
    {
        Name = name;

        UIElement = new TextBox();

        Design();
    }

    public void Design()
    {
        UIElement.Width = 300;
        UIElement.Padding = new Thickness(5);
    }
}
