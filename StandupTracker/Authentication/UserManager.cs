using AutoMapper;
using StandupTracker.Applications;
using StandupTracker.Applications.Dtos;
using StandupTracker.Applications.Exeptions;
using StandupTracker.Applications.Services.Authentication;
using StandupTracker.Applications.Validations;
using StandupTracker.Components;
using StandupTracker.Menu;
using System.Diagnostics;
using System.Windows.Controls;

namespace StandupTracker.Authentication;

public class UserManager
{
    public bool IsAuthenticated { get; set; }

    private IMapper Mapper { get; }
    private UserCreateValidator CreateValidator { get; } 

    public UserManager()
    {
        IsAuthenticated = false;

        Mapper = new MapperConfiguration(cfg => 
        cfg.AddMaps(typeof(DtoEntityMapperProfile))).CreateMapper();

        CreateValidator = new UserCreateValidator();

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
}
