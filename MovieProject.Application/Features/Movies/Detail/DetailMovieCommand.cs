using System;
using Mediator;
using MovieProject.Application.Features.Actor;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Movies;

public class DetailMovieCommand : IRequest<ResponseModel<ListMovieResponse?>>
{
    public string Id { set; get; }

    public DetailMovieCommand(string Id)
    {
        this.Id = Id;
    }
}
