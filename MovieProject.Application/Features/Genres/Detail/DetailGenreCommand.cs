using System;
using Mediator;
using MovieProject.Application.Features.Actor;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Genres;

public class DetailGenreCommand : IRequest<ResponseModel<ListGenreResponse?>>
{
    public string Id { set; get; }

    public DetailGenreCommand(string Id)
    {
        this.Id = Id;
    }
}
