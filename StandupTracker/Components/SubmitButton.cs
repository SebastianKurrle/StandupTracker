using System.Windows;
using System.Windows.Controls;

namespace StandupTracker.Components;

class SubmitButton : IComponent
{
    public string Name { get; set; }
    public Button UIElement { get; set; }

    public SubmitButton(string name, string content)
    {
        Name = name;

        UIElement = new Button();
        UIElement.Content = content;

        Design();
    }

    public void Design()
    {
        UIElement.Width = 300;
        UIElement.Margin = new Thickness(0, 10, 0, 0);
        UIElement.Padding = new Thickness(5);
    }
}
