using System;
using System.ComponentModel.DataAnnotations;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.Reviews;

public class CreateReviewCommand : IRequest<ResponseModel<string>>, IValidatableObject
{
    [Required]
    public string? UserId { set; get; }
    public string? MovieId { set; get; }
    public string? EpisodeId { set; get; }
    [Required]
    public decimal Rating { set; get; }
    [Required]
    public string Comment { set; get; }

    public Review ToDomainEntity()
    {
        return new Review
        {
            Id = Guid.NewGuid().ToString(),
            UserId = UserId ?? "",
            MovieId = MovieId ?? "",
            EpisodeId = EpisodeId ?? "",
            Rating = Rating,
            Comment = Comment,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(MovieId) && string.IsNullOrEmpty(EpisodeId))
        {
            yield return new ValidationResult("Please fill the one of them with value MovieId or EpisodeId.");
        }
        else if((!string.IsNullOrEmpty(MovieId) && !string.IsNullOrEmpty(EpisodeId)))
        {
            yield return new ValidationResult("Please Add Only one value MovieId or EpisodeId.");
        }
    }
}
