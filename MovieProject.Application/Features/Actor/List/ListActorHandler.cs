using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Actor;

public class ListActorHandler(ICrudRepository<Actors, Object> repository) : IRequestHandler<ListActorQuery, ResponseModel<List<ListActorResponse>>>
{
    public async ValueTask<ResponseModel<List<ListActorResponse>>> Handle(ListActorQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.getList(request,cancellationToken);
        return new ResponseModel<List<ListActorResponse>>
        {
            data = list.Select(p => new ListActorResponse(p)).ToList(),
            Status = "OK",
            Message = "Successfully Fetched"
        };
    }
}
