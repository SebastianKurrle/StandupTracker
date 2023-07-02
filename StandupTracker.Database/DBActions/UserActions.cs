using StandupTracker.Database.Entities;
using StandupTracker.Database.Exeptions;

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

    public static User GetUserByUsername(string username)
    {
        InitDB initDB = new();

        var user = new User();

        using (initDB.Context)
        {
            user = initDB.Context.Users.FirstOrDefault(user => user.Username.Equals(username));
        }

        if (user == null)
            throw new UserNotFoundExeption();

        return user;
    }
}
