namespace StandupTracker.Database;

public class InitDB
{
    public StandupTrackerContext Context { get; set; }

    public InitDB()
    {
        Context = new StandupTrackerContext();
    }
}
