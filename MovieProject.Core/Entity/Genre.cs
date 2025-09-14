using System;
using System.ComponentModel.DataAnnotations;

namespace MovieProject.Core.Entity;

public class Genre
{
    [Key]
    public string Id { set; get; }
    public string Name { set; get; }
    public string Description { set; get; } = "";
    public DateTime CreatedAt { set; get; } = DateTime.UtcNow;
    public DateTime UpdatedAt{ set; get; } = DateTime.UtcNow;
}
