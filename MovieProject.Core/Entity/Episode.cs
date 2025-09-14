using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieProject.Core.Entity;

public class Episode
{
    [Key]
    public string Id { set; get; }
    public string SeasonId { set; get; }
    [ForeignKey(nameof(SeasonId))]
    public virtual Seasons? Season { set; get; }
    public string Title { set; get; }
    public int EpisodeNumber { set; get; }
    public string Description { set; get; }
    public DateTime ReleaseDate { set; get; }
    public string VideoUrl { set; get; }
    public int DurationInMinutes { set; get; }
    public DateTime CreatedAt { set; get; }= DateTime.UtcNow;
    public DateTime UpdatedAt { set; get; }= DateTime.UtcNow;
}
