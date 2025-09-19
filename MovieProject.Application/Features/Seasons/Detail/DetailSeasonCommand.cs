using System;
using Mediator;
using MovieProject.Application.Features.Actor;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Seasons;

public class DetailSeasonCommand : IRequest<ResponseModel<ListSeasonResponse?>>
{
    public string Id { set; get; }

    public DetailSeasonCommand(string Id)
    {
        this.Id = Id;
    }
}
