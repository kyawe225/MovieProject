using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Seasons;

public class DeleteSeasonCommand : IRequest<ResponseModel<Unit?>>
{
    public string Id { set; get; }
    public DeleteSeasonCommand(string Id)
    {
        this.Id = Id;
    }
}
