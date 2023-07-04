using StandupTracker.Exeptions;
using StandupTracker.Views;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StandupTracker.Menu;

public class MenuManager
{
    public static readonly List<MenuItem> menuItems = new();
    public static readonly List<View> views = new()
    {
        new RegisterView(new StackPanel()
        {
            Name = "registerStackPanel",
            Visibility = Visibility.Collapsed,
        }),

        new LoginView(new StackPanel()
        {
            Name = "loginStackPanel",
            Visibility = Visibility.Collapsed,
        })
    };
    
    // Fills the menu items for a unauthenticated user
    public static void CreateUnauthenticatedMenu()
    {
        menuItems.Clear();

        menuItems.Add(new MenuItem("Registrieren", "registerStackPanel"));
        menuItems.Add(new MenuItem("Login", "loginStackPanel"));
    }

    public static void ChangeView(MenuItem menuItem)
    {
        ClearViews();

        foreach(View view in views)
        {
            if (view.StackPanel.Name == menuItem.PanelName) 
            {
                view.StackPanel.Visibility = Visibility.Visible;
                return;
            }
        }

        throw new StackPanelNotFoundExeption();
    }

    // Clears the current view
    private static void ClearViews()
    {
        foreach(View view in views)
        {
            view.StackPanel.Visibility = Visibility.Collapsed;
        }
    }
}
