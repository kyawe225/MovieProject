using System;
using System.ComponentModel.DataAnnotations;

namespace MovieProject.Core.Entity;

public class Movie
{
    [Key]
    public string Id { set; get; }
    public string Title { set; get; }
    public string Description { set; get; }
    public DateTime ReleaseDate { set; get; }
    public string PosterUrl { set; get; }
    public decimal Rating { set; get; } // this should be rotten tomato rating
    public long DurationInMinutes { set; get; }
    public DateTime CreatedAt { set; get; }= DateTime.UtcNow;
    public DateTime UpdatedAt { set; get; }= DateTime.UtcNow;
}
