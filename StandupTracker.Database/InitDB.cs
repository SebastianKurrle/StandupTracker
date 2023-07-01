using StandupTracker.DB;

namespace StandupTracker.Database;

public class InitDB
{
    public InitDB()
    {
        StandupTrackerContext context = new StandupTrackerContext();
    }
}
