using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using StandupTracker.DB.Entities;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace StandupTracker.DB;

public class StandupTrackerContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<DayNote> DayNotes { get; set; }

    
}
