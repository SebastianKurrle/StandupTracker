using AutoMapper;
using FluentValidation;
using StandupTracker.Applications.Contracts;
using StandupTracker.Applications.Dtos;
using StandupTracker.Applications.Validations;
using StandupTracker.Database;
using StandupTracker.Database.DBActions;
using StandupTracker.Database.Entities;

namespace StandupTracker.Applications.Services.Authentication;

public class AuthenticationCreateService
{
    public IMapper Mapper { get; }
    public UserCreateValidator UserCreateValidator { get; }

    public AuthenticationCreateService(IMapper mapper,
        UserCreateValidator userCreateValidator)
    {
        Mapper = mapper;
        UserCreateValidator = userCreateValidator;
    }

    public void CreateUser(UserCreate userCreate)
    {
        UserCreateValidator.ValidateAndThrow(userCreate);
        var user = Mapper.Map<User>(userCreate);

        UserActions.UserCreateAction(user);
    }

}
