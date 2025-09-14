using System;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.Actor;

public class ListActorResponse
{
    public string Id { set; get; }
    public string Name { set; get; }
    public string BirthDate { set; get; }
    public string Nationality { set; get; }
    public DateTime CreatedAt { set; get; }
    public DateTime UpdatedAt { set; get; }

    public ListActorResponse(Actors actors)
    {
        Id = actors.Id;
        Nationality = actors.Nationality;
        CreatedAt = actors.CreatedAt;
        UpdatedAt = actors.UpdatedAt;
        BirthDate = actors.BirthDate;
        Name = actors.Name;
    }
}
