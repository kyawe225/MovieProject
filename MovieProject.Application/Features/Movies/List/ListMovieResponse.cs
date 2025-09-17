using Microsoft.AspNetCore.Http;
using MovieProject.Core.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieProject.Application.Features.Movies;

public class ListMovieResponse
{
    public string Id { set; get; }

    public string Title { set; get; }

    public string Description { set; get; }

    public DateTime ReleaseDate { set; get; }

    public string PosterUrl { set; get; }

    public decimal Rating { set; get; } // this should be rotten tomato rating

    public long DurationInMinutes { set; get; }
    public DateTime CreatedAt { set; get; }
    public DateTime UpdatedAt { set; get; }

    public ListMovieResponse(Movie entity)
    {
        Id = entity.Id;
        Title = entity.Title;
        Description = entity.Description;
        ReleaseDate = entity.ReleaseDate;
        PosterUrl = entity.PosterUrl;
        Rating = entity.Rating;
        DurationInMinutes = entity.DurationInMinutes;
        CreatedAt = entity.CreatedAt;
        UpdatedAt = entity.UpdatedAt;
    }
}
