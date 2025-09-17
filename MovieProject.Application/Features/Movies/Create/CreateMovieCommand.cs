using System;
using System.ComponentModel.DataAnnotations;
using Mediator;
using Microsoft.AspNetCore.Http;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.Movies;

public class CreateMovieCommand : IRequest<ResponseModel<string>>
{
    [Required]
    public string Title { set; get; }
    [Required]
    public string Description { set; get; }
    [Required]
    public DateTime ReleaseDate { set; get; }
    [Required]
    public IFormFile PosterUrl { set; get; }
    [Required]
    public decimal Rating { set; get; } // this should be rotten tomato rating
    [Required]
    public long DurationInMinutes { set; get; }

    public Movie ToDomainEntity()
    {
        return new Movie
        {
            Id = Guid.NewGuid().ToString(),
            Title = Title,
            Description = Description,
            ReleaseDate = ReleaseDate,
            //PosterUrl = PosterUrl,
            Rating = Rating,
            DurationInMinutes = DurationInMinutes,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
}
