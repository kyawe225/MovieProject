using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Director;

public class ListDirectorHandler(ICrudRepository<Directors, Object> repository) : IRequestHandler<ListDirectorQuery, ResponseModel<List<ListDirectorResponse>>>
{
    public async ValueTask<ResponseModel<List<ListDirectorResponse>>> Handle(ListDirectorQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.getList(request,cancellationToken);
        return new ResponseModel<List<ListDirectorResponse>>
        {
            data = list.Select(p => new ListDirectorResponse(p)).ToList(),
            Status = "OK",
            Message = "Successfully Fetched"
        };
    }
}
