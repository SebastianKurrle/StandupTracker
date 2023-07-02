using StandupTracker.Database.Entities;

namespace StandupTracker.Database.DBActions;

public class UserActions
{
    public static void UserCreateAction(User newUser)
    {
        InitDB initDB = new();

        using (initDB.Context)
        {
            initDB.Context.Users.Add(newUser);

            initDB.Context.SaveChanges();
        }
    }
}
