using StandupTracker.Exeptions;
using StandupTracker.Views;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StandupTracker.Menu;

public class MenuManager
{
    public static Grid WindowLayout { get; set; } = default!;
    public static ComboBox MenuControl { get; set; } = default!;
    public static readonly List<MenuItem> menuItems = new();

    public static readonly List<View> views = new();

    public static void AddStackPanelsToWindow()
    {
        foreach (View view in views)
        {
            Grid.SetRow(view.StackPanel, 1);
            Grid.SetColumn(view.StackPanel, 0);
            Grid.SetColumnSpan(view.StackPanel, 2);
            WindowLayout.Children.Add(view.StackPanel);
        }
    }

    // Fills the menu items for a unauthenticated user
    public static void CreateUnauthenticatedMenu()
    {
        ClearViews();
        views.Clear();
        views.Add(
             new RegisterView(new StackPanel()
             {
                 Name = "registerStackPanel",
                 Visibility = Visibility.Collapsed,
             })
        );
        
        views.Add(
             new LoginView(new StackPanel()
             {
                 Name = "loginStackPanel",
                 Visibility = Visibility.Collapsed,
             })
        );

        menuItems.Clear();

        menuItems.Add(new MenuItem("Registrieren", "registerStackPanel"));
        menuItems.Add(new MenuItem("Login", "loginStackPanel"));
    }

    public static void UserLogout()
    {
        CreateUnauthenticatedMenu();
        AddStackPanelsToWindow();
        MenuControl.SelectedItem = GetMenuItemByPanelName("loginStackPanel");
        MenuControl.Items.Refresh();
    }

    public static void CreateUserMenu()
    {
        ClearViews();
        views.Clear();
        views.Add(
            new HomeView(new StackPanel()
            {
                Name = "homeStackPanel",
                Visibility = Visibility.Collapsed,
            })
        );

        AddStackPanelsToWindow();

        menuItems.Clear();

        menuItems.Add(new MenuItem("Home", "homeStackPanel"));
        menuItems.Add(new MenuItem("Neuer Track", "newTrackStackPanel"));
        menuItems.Add(new MenuItem("Neuer Trackbenutzer", "newTrackuserStackPanel"));

        MenuControl.ItemsSource = menuItems;
        MenuControl.SelectedItem = GetMenuItemByPanelName("homeStackPanel");
        MenuControl.Items.Refresh();
    }

    public static MenuItem GetMenuItemByPanelName(string panelName)
    {
        foreach (MenuItem item in menuItems)
        {
            if (item.PanelName == panelName)
                return item;
        }

        throw new StackPanelNotFoundExeption();
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
