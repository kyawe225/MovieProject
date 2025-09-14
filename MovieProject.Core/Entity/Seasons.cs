using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieProject.Core.Entity;

public class Seasons
{
    [Key]
    public string Id { set; get; }
    public string SeriesId { set; get; }
    [ForeignKey(nameof(SeriesId))]
    public virtual Series? Series { set; get; }
    public string SeasonNumber { set; get; }
    public int ReleaseYear { set; get; }
    public DateTime CreatedAt { set; get; } = DateTime.UtcNow;
    public DateTime UpdatedAt { set; get; } = DateTime.UtcNow;
}
