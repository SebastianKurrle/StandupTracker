using System.Windows;
using System.Windows.Controls;

namespace StandupTracker.Components;

public class MenuControl : IComponent
{
    public string Name { get; set; }
    public ComboBox UIElement { get; set; }
    public ItemContainerTemplate ItemTemplate { get; set; }
    public DataTemplate DataTemplate { get; set; }

    public MenuControl(string name)
    {
        Name = name;

        UIElement = new();
        ItemTemplate = new();
        DataTemplate = new();
    }

    public void Design()
    {
        
    }
}
