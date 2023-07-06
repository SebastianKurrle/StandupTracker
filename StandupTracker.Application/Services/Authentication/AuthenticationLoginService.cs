using AutoMapper;
using FluentValidation;
using Standuptracker.AuthenticationTokens;
using Standuptracker.AuthenticationTokens.Dtos;
using StandupTracker.Applications.Dtos;
using StandupTracker.Applications.Exeptions;
using StandupTracker.Applications.Validations;
using StandupTracker.Database.DBActions;
using StandupTracker.Database.Entities;
using System.Diagnostics;

namespace StandupTracker.Applications.Services.Authentication;

public class AuthenticationLoginService
{
    public IMapper Mapper { get; }
    public UserLoginValidator UserLoginValidator { get; }

    public AuthenticationLoginService(IMapper mapper, UserLoginValidator userLoginValidator)
    {
        Mapper = mapper;
        UserLoginValidator = userLoginValidator;
    }

    public string LoginUser(UserLogin userLogin)
    {
        UserLoginValidator.ValidateAndThrow(userLogin);
        var user = Mapper.Map<User>(userLogin);

        if (UserActions.CheckIfUserExists(user) == false)
            throw new UserNotFoundExeption();

        User dbUser = UserActions.GetUserByUsername(user.Username);

        if (CheckIfPasswordsMatching(user, dbUser) == false)
            throw new IncorrectCredentialsException();

        string token = JWTToken.CreateToken(dbUser);
        return token;
    }

    public static LoggedInUser GetLoggedInUserFromToken(string token)
    {
        return JWTToken.GetLoggedInUserFromToken(token);
    }

    private bool CheckIfPasswordsMatching(User requestLoginUser, User dbUser)
    {
        return requestLoginUser.Password == dbUser.Password;
    }

}
