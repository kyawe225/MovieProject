using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Movies;

public class DeleteMovieCommand : IRequest<ResponseModel<Unit?>>
{
    public string Id { set; get; }
    public DeleteMovieCommand(string Id)
    {
        this.Id = Id;
    }
}
