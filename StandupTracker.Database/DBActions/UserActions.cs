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

    public static bool CheckIfUserExists(User user)
    {
        InitDB initDB = new();

        using(initDB.Context)
        {
            var users = initDB.Context.Users;

            foreach (User u in users)
            {
                if (u.Username.Equals(user.Username))
                    return true;
            }

            return false;
        }
    }
}
