using AutoMapper;
using Standuptracker.AuthenticationTokens.Dtos;
using StandupTracker.Applications;
using StandupTracker.Applications.Dtos;
using StandupTracker.Applications.Exeptions;
using StandupTracker.Applications.Services.Authentication;
using StandupTracker.Applications.Validations;
using StandupTracker.Components;
using StandupTracker.Exeptions;
using StandupTracker.Menu;
using System.Diagnostics;
using System.Windows.Controls;

namespace StandupTracker.Authentication;

public class UserManager
{
    public bool IsAuthenticated { get; set; }
    public LoggedInUser? CurrentUser { get; set; } = default!;

    private IMapper Mapper { get; }
    private UserCreateValidator CreateValidator { get; } 
    private UserLoginValidator LoginValidator { get; }

    public UserManager()
    {
        IsAuthenticated = false;

        Mapper = new MapperConfiguration(cfg => 
        cfg.AddMaps(typeof(DtoEntityMapperProfile))).CreateMapper();

        CreateValidator = new UserCreateValidator();
        LoginValidator = new UserLoginValidator();

        MenuManager.CreateUnauthenticatedMenu();
    }

    public string CreateUser(UserCreate userCreate)
    {
        AuthenticationCreateService createService = new AuthenticationCreateService(Mapper, CreateValidator);

        string errors = string.Empty;

        try
        {
            createService.CreateUser(userCreate);
        }
        catch (UserAlreadyExistsExeption ex)
        {
           errors = "Ein Benutzer mit diesem Benutzer Namen Existiert bereits!\n" + 
                ex.Message;
        }
        catch
        {
            errors = "Ungültige Eingaben!";
        }

        return errors;
    }

    public string LoginUser(UserLogin userLogin)
    {
        AuthenticationLoginService loginService =
            new AuthenticationLoginService(Mapper, LoginValidator);

        string errors = string.Empty;

        try
        {
            string token = loginService.LoginUser(userLogin);
            AuthenticationStore.LoggedInUserToken = token;
            CurrentUser = AuthenticationLoginService.GetLoggedInUserFromToken(token);
            AuthenticationStore.SetAuthenticated(true);
        }
        catch (UserNotFoundExeption ex)
        {
            errors = "Der Benutzer wurde nicht gefunden\n" + ex.Message;
        }
        catch(IncorrectCredentialsException ex)
        {
            errors = "Falsches Passwort\n" + ex.Message;
        }
        catch
        {
            errors = "Ungütlige Eingaben";
        }

        return errors;
    }

    public void LogoutUser()
    {
        CurrentUser = null;
        AuthenticationStore.LoggedInUserToken = "";
        AuthenticationStore.SetAuthenticated(false);
        MenuManager.UserLogout();
    }
}
