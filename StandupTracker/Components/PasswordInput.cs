using System.Windows;
using System.Windows.Controls;

namespace StandupTracker.Components;

class PasswordInput : IComponent
{
    public string Name { get; set; }
    public PasswordBox UIElement { get; set; }

    public PasswordInput(string name)
    {
        Name = name;

        UIElement = new PasswordBox();

        Design();
    }

    public void Design()
    {
        UIElement.Width = 300;
        UIElement.Padding = new Thickness(5);
    }
}
