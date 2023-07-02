using AutoMapper;
using StandupTracker.Applications;
using StandupTracker.Applications.Dtos;
using StandupTracker.Applications.Services.Authentication;
using StandupTracker.Applications.Validations;

namespace StandupTracker.Authentication;

public class UserManager
{
    private IMapper Mapper { get; }
    private UserCreateValidator Validator { get; } 

    public UserManager()
    {
        Mapper = new MapperConfiguration(cfg => 
        cfg.AddMaps(typeof(DtoEntityMapperProfile))).CreateMapper();

        Validator = new UserCreateValidator();
    }

    public void CreateUser(UserCreate userCreate)
    {
        AuthenticationCreateService createService = new AuthenticationCreateService(Mapper, Validator);

        createService.CreateUser(userCreate);
    }
}
