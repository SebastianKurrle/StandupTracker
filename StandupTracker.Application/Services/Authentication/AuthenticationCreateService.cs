using AutoMapper;
using FluentValidation;
using StandupTracker.Application.Contracts;
using StandupTracker.Application.Dtos;
using StandupTracker.Application.Validations;
using StandupTracker.Database.Entities;

namespace StandupTracker.Application.Services.Authentication;

public class AuthenticationCreateService
{
    public IUserRepository UserRepository { get; }
    public IMapper Mapper { get; }
    public UserCreateValidator UserCreateValidator { get; }

    public AuthenticationCreateService(IUserRepository userRepository, IMapper mapper,
        UserCreateValidator userCreateValidator)
    {
        UserRepository = userRepository;
        Mapper = mapper;
        UserCreateValidator = userCreateValidator;
    }

    public void CreateUser(UserCreate userCreate)
    {
        UserCreateValidator.ValidateAndThrow(userCreate);
        var user = Mapper.Map<User>(userCreate);
        
        
    }

}
