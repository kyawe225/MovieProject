using System;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.Movies;

public class ListMovieResponse
{
    public string Id { set; get; }
    public string MovieId { set; get; }
    public string EpisodeId { set; get; }
    public decimal Rating { set; get; }
    public string Comment { set; get; }
    public string UserName { set; get; }
    public string UserId { set; get; }
    public DateTime CreatedAt { set; get; }
    public DateTime UpdatedAt { set; get; }

    public ListReviewResponse(Review entity)
    {
        Id = entity.Id;
        UserId = entity.UserId;
        MovieId = entity.MovieId;
        EpisodeId = entity.EpisodeId;
        UserName = entity.user?.Name;
        Rating = entity.Rating;
        Comment = entity.Comment;
        CreatedAt = entity.CreatedAt;
        UpdatedAt = entity.UpdatedAt;
    }
}
