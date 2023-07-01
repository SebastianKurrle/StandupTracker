using StandupTracker.Application.Dtos;
using StandupTracker.Application.Validations;

namespace StandupTracker.Tests.Validation;

public class UserCreateValidationTest
{
    private UserCreateValidator UserCreateValidator { get; }
        = new UserCreateValidator();

    [Fact]
    public void Valid_UserCreate_Passes_Validation()
    {
        // Arrange
        var userCreate = new UserCreate("Test", "testing321", "testing321");

        // Act
        var result = UserCreateValidator.Validate(userCreate);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validation_Error_For_Empty_Username()
    {
        // Arrange
        var userCreate = new UserCreate(string.Empty, "testing321", "testing321");

        // Act
        var result = UserCreateValidator.Validate(userCreate);

        // Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, error => 
        error.ErrorCode.Equals("NotEmptyValidator")
        && error.PropertyName.Equals("Username"));
    }

    [Fact]
    public void Validation_Error_For_Empty_Password()
    {
        // Arrange
        var userCreate = new UserCreate("Test", string.Empty, string.Empty);

        // Act
        var result = UserCreateValidator.Validate(userCreate);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error =>
        error.ErrorCode.Equals("NotEmptyValidator")
        && error.PropertyName.Equals("Password1"));
    }

    [Fact]
    public void Validation_Error_For_Too_Short_Password()
    {
        // Arrange
        var userCreate = new UserCreate("Test", "test", "test");

        // Act
        var result = UserCreateValidator.Validate(userCreate);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error =>
        error.ErrorCode.Equals("MinimumLengthValidator")
        && error.PropertyName.Equals("Password1"));
    }

    [Fact]
    public void Validation_Error_For_Password1_Not_Matching_Password2()
    {
        // Arrange
        var userCreate = new UserCreate("Test", "testing321", "testing3211");

        // Act
        var result = UserCreateValidator.Validate(userCreate);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error =>
        error.ErrorCode.Equals("EqualValidator")
        && error.PropertyName.Equals("Password2"));
    }
}
