using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StandupTracker.Database.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Username { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;
}
