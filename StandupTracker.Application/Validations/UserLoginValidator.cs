using FluentValidation;
using StandupTracker.Applications.Dtos;

namespace StandupTracker.Applications.Validations;

public class UserLoginValidator : AbstractValidator<UserLogin>
{
    // Validates the UserLogin
    /*
        Rules:
        1. The username not empty
        2. The Password not empty
    */
    public UserLoginValidator()
    {
        RuleFor(user =>  user.Username).NotEmpty();
        RuleFor(user => user.Password).NotEmpty();
    }
}