using StandupTracker.Applications.Dtos;
using StandupTracker.Authentication;
using StandupTracker.Components;
using StandupTracker.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StandupTracker.Views;

public class RegisterView : View
{
    private Input UsernameInput { get; set; } = default!;
    private PasswordInput PasswordInput { get; set; } = default!;
    private PasswordInput Password2Input { get; set; } = default!;
    private ErrorLabel ErrorRegisterLabel { get; set; } = default!;

    public RegisterView(StackPanel stackPanel) : base(stackPanel)
    {
        InitUI();
        AddChildrenToPanel();
    }

    public override void InitUI()
    {
        HeadLineLabel headLineLabel = new("Registrieren");

        InputLabel usernameInputLabel = new("Benutzername");
        UsernameInput = new("usernameRegisterInput");

        InputLabel passwordInputLabel = new("Passwort");
        PasswordInput  = new("passwordRegisterInput");

        InputLabel password2InputLabel = new("Passwort Wiederholen");
        Password2Input = new("password2RegisterInput");

        SubmitButton registerButton = new("buttonRegister", "Registrieren");

        registerButton.UIElement.Click += RegisterButton_Click;

        ErrorRegisterLabel = new("");

        // Headline
        Children.Add(headLineLabel.UIElement);

        // Username
        Children.Add(usernameInputLabel.UIElement);
        Children.Add(UsernameInput.UIElement);

        // Password
        Children.Add(passwordInputLabel.UIElement);
        Children.Add(PasswordInput.UIElement);

        // Password2
        Children.Add(password2InputLabel.UIElement);
        Children.Add(Password2Input.UIElement);

        // Register button
        Children.Add(registerButton.UIElement);

        // Errors
        Children.Add(ErrorRegisterLabel.UIElement);
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        ErrorRegisterLabel.UIElement.Content = "";

        UserCreate newUser = new(UsernameInput.UIElement.Text,
            PasswordInput.UIElement.Password, Password2Input.UIElement.Password);

        string result = AuthenticationStore.UserManager.CreateUser(newUser);

        ValidateResult(result);
        ClearInputs();

        RedirectToLogin();
    }

    private void ValidateResult(string result)
    {
        if (result != string.Empty)
        {
            ErrorRegisterLabel.UIElement.Content = result;
        }
    }

    private void ClearInputs()
    {
        UsernameInput.UIElement.Text = string.Empty;
        PasswordInput.UIElement.Password = string.Empty;
        Password2Input.UIElement.Password = string.Empty;
    }

    private void RedirectToLogin()
    {
        Menu.MenuItem item = MenuManager.GetMenuItemByPanelName("loginStackPanel");

        MenuManager.ChangeView(item);
    }
}
