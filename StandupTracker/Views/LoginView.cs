using StandupTracker.Applications.Dtos;
using StandupTracker.Authentication;
using StandupTracker.Components;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace StandupTracker.Views;

public class LoginView : View
{
    private Input UsernameInput { get; set; } = default!;
    private PasswordInput PasswordInput { get; set; } = default!;
    private ErrorLabel ErrorLoginLabel { get; set; } = default!;

    public LoginView(StackPanel stackPanel) : base(stackPanel)
    {
        InitUI();
        AddChildrenToPanel();
    }

    public override void InitUI()
    {
        HeadLineLabel headLineLabel = new("Login");

        InputLabel usernameInputLabel = new("Benutzername");
        UsernameInput = new("usernameLoginInput");

        InputLabel passwordInputLabel = new("Passwort");
        PasswordInput = new("passwordLoginInput");

        SubmitButton registerButton = new("buttonLogin", "Login");

        registerButton.UIElement.Click += LoginButton_Click;

        ErrorLoginLabel = new("");

        // Headline
        Children.Add(headLineLabel.UIElement);

        // Username
        Children.Add(usernameInputLabel.UIElement);
        Children.Add(UsernameInput.UIElement);

        // Password
        Children.Add(passwordInputLabel.UIElement);
        Children.Add(PasswordInput.UIElement);

        // Register button
        Children.Add(registerButton.UIElement);

        // Errors
        Children.Add(ErrorLoginLabel.UIElement);
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        ErrorLoginLabel.UIElement.Content = "";

        UserLogin userLogin = new(UsernameInput.UIElement.Text,
            PasswordInput.UIElement.Password);

        string result = AuthenticationStore.UserManager.LoginUser(userLogin);

        ValidateResult(result);
        ClearInputs();
    }

    private void ValidateResult(string result)
    {
        if (result != string.Empty)
        {
            ErrorLoginLabel.UIElement.Content = result;
        }
    }

    private void ClearInputs()
    {
        UsernameInput.UIElement.Text = string.Empty;
        PasswordInput.UIElement.Password = string.Empty;
    }
}
