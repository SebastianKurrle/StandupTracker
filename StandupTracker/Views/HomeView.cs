using Standuptracker.AuthenticationTokens.Dtos;
using StandupTracker.Authentication;
using StandupTracker.Components;
using StandupTracker.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace StandupTracker.Views;

public class HomeView : View
{
    public HomeView(StackPanel stackPanel) : base(stackPanel)
    {
        InitUI();
        AddChildrenToPanel();
    }

    public override void InitUI()
    {
        HeadLineLabel headLineLabel = new("Home");
        SubmitButton loggoutButton = new("buttonLogout", "Ausloggen");
        loggoutButton.UIElement.Background = Brushes.DarkRed;
        loggoutButton.UIElement.Foreground = Brushes.White;

        InfoLabel infoLabel = new("Eingeloggt als: " + 
            AuthenticationStore.UserManager.CurrentUser.Username);

        Children.Add(headLineLabel.UIElement);
        Children.Add(loggoutButton.UIElement);
        Children.Add(infoLabel.UIElement);
    }
}
