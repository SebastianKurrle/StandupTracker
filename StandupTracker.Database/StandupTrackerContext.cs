using StandupTracker.Database.Entities;
using System.Configuration;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace StandupTracker.DB;

public class StandupTrackerContext : DbContext
{
    public StandupTrackerContext() : base(GetConnectionString())
    {    
    }

    public static string GetConnectionString()
    {
        return "data source=SEBASTIANKURRLE\\SEBASTIAN; initial catalog=StandupTracker; integrated security=SSPI;";
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<DayNote> DayNotes { get; set; }
}
