using System;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.Genres;

public class ListGenreResponse
{
    public string Id { set; get; }
    public string Name { set; get; }
    public string Description { set; get; }
    public DateTime CreatedAt { set; get; }
    public DateTime UpdatedAt { set; get; }

    public ListGenreResponse(Genre entity)
    {
        Id = entity.Id;
        Description = entity.Description;
        CreatedAt = entity.CreatedAt;
        UpdatedAt = entity.UpdatedAt;
        Name = entity.Name;
    }
}
