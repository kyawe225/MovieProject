using System;
using System.ComponentModel.DataAnnotations;

namespace MovieProject.Core.Entity;

public class WatchList
{
    [Key]
    public string Id { set; get; }
    public string UserId { set; get; }
    public string? MovieId { set; get; }
    public string? EpisodeId { set; get; }
    public DateTime CreatedAt { set; get; }= DateTime.UtcNow;
    public DateTime UpdatedAt { set; get; }= DateTime.UtcNow;
}
