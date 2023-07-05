namespace StandupTracker.Authentication;

public static class AuthenticationStore
{
    public static UserManager UserManager { get; set; } = new UserManager();
    public static string LoggedInUserToken { get; set; } = "";

    public static void SetAuthenticated(bool authenticated)
    {
        UserManager.IsAuthenticated = authenticated;
    }
}
