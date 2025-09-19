using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Seasons;

public class ListSeasonHandler(ICrudRepository<Season, Object> repository) : IRequestHandler<ListSeasonQuery, ResponseModel<List<ListSeasonResponse>>>
{
    public async ValueTask<ResponseModel<List<ListSeasonResponse>>> Handle(ListSeasonQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.getList(request,cancellationToken);
        return new ResponseModel<List<ListSeasonResponse>>
        {
            data = list.Select(p => new ListSeasonResponse(p)).ToList(),
            Status = "OK",
            Message = "Successfully Fetched"
        };
    }
}
