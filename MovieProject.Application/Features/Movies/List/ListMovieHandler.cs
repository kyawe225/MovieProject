using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Movies;

public class ListMovieHandler(ICrudRepository<Movie, Object> repository) : IRequestHandler<ListMovieQuery, ResponseModel<List<ListMovieResponse>>>
{
    public async ValueTask<ResponseModel<List<ListMovieResponse>>> Handle(ListMovieQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.getList(request,cancellationToken);
        return new ResponseModel<List<ListMovieResponse>>
        {
            data = list.Select(p => new ListMovieResponse(p)).ToList(),
            Status = "OK",
            Message = "Successfully Fetched"
        };
    }
}
