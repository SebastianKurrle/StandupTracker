using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace StandupTracker.Views;

public abstract class View
{
    public List<UIElement> Children { get; set; }
    public StackPanel StackPanel { get; set; }

    public View(StackPanel stackPanel)
    {
        Children = new List<UIElement>();
        StackPanel = stackPanel;
    }

    public abstract void InitUI();

    public void AddChildrenToPanel()
    {
        foreach (UIElement child in Children)
        {
            StackPanel.Children.Add(child);
        }
    }
}
