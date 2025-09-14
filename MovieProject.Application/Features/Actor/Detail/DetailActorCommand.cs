using System;
using Mediator;
using MovieProject.Application.Features.Actor;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Actor;

public class DetailActorCommand : IRequest<ResponseModel<ListActorResponse?>>
{
    public string Id { set; get; }

    public DetailActorCommand(string Id)
    {
        this.Id = Id;
    }
}
