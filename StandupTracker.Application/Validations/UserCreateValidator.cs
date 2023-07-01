using FluentValidation;
using StandupTracker.Application.Dtos;

namespace StandupTracker.Application.Validations;

public class UserCreateValidator : AbstractValidator<UserCreate>
{
    // Validates the UserCreate
    /*
        Rules:
        1. The username not empty and maximum length 50
        2. First password not empty and minimum length 8
        3. Repeated password (password2) not empty, minimum length 8 and equals password1
    */
    public UserCreateValidator()
    {
        RuleFor(user => user.Username).NotEmpty().MaximumLength(50);
        RuleFor(user => user.Password1).NotEmpty().MinimumLength(8);
        RuleFor(user => user.Password2).NotEmpty().MinimumLength(8).Equal(user => user.Password1);
    }
}
