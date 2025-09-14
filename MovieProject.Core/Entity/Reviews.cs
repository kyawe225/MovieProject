using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieProject.Core.Entity;

public class Review
{
    [Key]
    public string Id { set; get; }
    public string UserId { set; get; }
    [ForeignKey(nameof(UserId))]
    public virtual User? user { set; get; }
    public string MovieId { set; get; }
    [ForeignKey(nameof(MovieId))]
    public Movie Movie { set; get; }
    public string EpisodeId { set; get; }
    [ForeignKey(nameof(EpisodeId))]
    public Episode Episode { set; get; }
    public decimal Rating { set; get; }
    public string Comment { set; get; }
    public DateTime CreatedAt { set; get; } = DateTime.UtcNow;
    public DateTime UpdatedAt { set; get; } = DateTime.UtcNow;
}
