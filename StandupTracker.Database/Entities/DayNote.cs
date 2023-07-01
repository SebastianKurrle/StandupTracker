using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StandupTracker.Database.Entities;

public class DayNote
{
    public DayNote(string title, string description, Guid createrId)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        CreatedDate = DateTime.Now;
        CreaterId = createrId;
    }

    [Key]
    public Guid Id { get; set; }
    [Required, StringLength(50)]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }

    [ForeignKey("Creater")]
    public Guid CreaterId { get; set; }
    
    public virtual User Creater { get; set; }
}
