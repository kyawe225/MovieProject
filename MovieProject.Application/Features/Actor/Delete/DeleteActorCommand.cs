using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Actor;

public class DeleteActorCommand : IRequest<ResponseModel<Unit?>>
{
    public string Id { set; get; }
    public DeleteActorCommand(string Id)
    {
        this.Id = Id;
    }
}
