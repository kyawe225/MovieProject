using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieProject.Application.Features.Reviews;

public class UpdateReviewCommand : IRequest<ResponseModel<Unit?>>
{
    public string Id { set; get; }
    [Required]
    public string UserId { set; get; }
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
            UserId = UserId,
            MovieId = MovieId ?? "",
            EpisodeId = EpisodeId ?? "",
            Rating = Rating,
            Comment = Comment
        };
    }
}
