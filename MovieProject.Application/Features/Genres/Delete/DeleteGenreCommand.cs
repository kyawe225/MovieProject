using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Genres
    ;

public class DeleteGenreCommand : IRequest<ResponseModel<Unit?>>
{
    public string Id { set; get; }
    public DeleteGenreCommand(string Id)
    {
        this.Id = Id;
    }
}
