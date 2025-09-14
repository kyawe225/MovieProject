using System;
using System.ComponentModel.DataAnnotations;

namespace MovieProject.Core.Entity;

public class Directors
{
    [Key]
    public string Id { set; get; }
    public string Name { set; get; }
    public string BirthDate { set; get; }
    public DateTime JoinedDate { set; get; }
    public DateTime CreatedAt { set; get; } = DateTime.UtcNow;
    public DateTime UpdatedAt { set; get; } = DateTime.UtcNow;
}
