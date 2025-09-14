using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Movies;

public class DetailMovieHandler(ICrudRepository<Movie, Object> _repository) : IRequestHandler<DetailMovieCommand, ResponseModel<ListMovieResponse?>>
{
    public async ValueTask<ResponseModel<ListMovieResponse?>> Handle(DetailMovieCommand request, CancellationToken cancellationToken)
    {
        var data = await Task.Run(() => _repository.getDetail(request.Id),cancellationToken);
        if (data == null)
        {
            return new ResponseModel<ListMovieResponse?>()
            {
                data = null,
                Message = "data not found",
                Status = "404"
            };
        }
        return new ResponseModel<ListMovieResponse?>()
        {
            data = new ListMovieResponse(data),
            Message = "data fetch successfully",
            Status = "200"
        };
    }
}
