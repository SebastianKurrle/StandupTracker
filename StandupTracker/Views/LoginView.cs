using StandupTracker.Components;
using System.Windows.Controls;

namespace StandupTracker.Views;

public class LoginView : View
{
    public LoginView(StackPanel stackPanel) : base(stackPanel)
    {
        InitUI();
        AddChildrenToPanel();
    }

    public override void InitUI()
    {
        HeadLineLabel headLineLabel = new("Login");

        Children.Add(headLineLabel.UIElement);
    }
}
