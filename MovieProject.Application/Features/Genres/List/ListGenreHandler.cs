using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Genres;

public class ListReviewHandler(ICrudRepository<Genre, Object> repository) : IRequestHandler<ListGenreQuery, ResponseModel<List<ListGenreResponse>>>
{
    public async ValueTask<ResponseModel<List<ListGenreResponse>>> Handle(ListGenreQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.getList(request,cancellationToken);
        return new ResponseModel<List<ListGenreResponse>>
        {
            data = list.Select(p => new ListGenreResponse(p)).ToList(),
            Status = "OK",
            Message = "Successfully Fetched"
        };
    }
}
