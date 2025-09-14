using System;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.Director;

public class ListDirectorResponse
{
    public string Id { set; get; }
    public string Name { set; get; }
    public string BirthDate { set; get; }
    public DateTime JoinedDate { set; get; }
    public DateTime CreatedAt { set; get; }
    public DateTime UpdatedAt { set; get; }

    public ListDirectorResponse(Directors actors)
    {
        Id = actors.Id;
        JoinedDate = actors.JoinedDate;
        CreatedAt = actors.CreatedAt;
        UpdatedAt = actors.UpdatedAt;
        BirthDate = actors.BirthDate;
        Name = actors.Name;
    }
}
