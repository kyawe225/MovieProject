using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Genres;

public class DetailReviewHandler(ICrudRepository<Genre, Object> _repository) : IRequestHandler<DetailGenreCommand, ResponseModel<ListGenreResponse?>>
{
    public async ValueTask<ResponseModel<ListGenreResponse?>> Handle(DetailGenreCommand request, CancellationToken cancellationToken)
    {
        var data = await Task.Run(() => _repository.getDetail(request.Id),cancellationToken);
        if (data == null)
        {
            return new ResponseModel<ListGenreResponse?>()
            {
                data = null,
                Message = "data not found",
                Status = "404"
            };
        }
        return new ResponseModel<ListGenreResponse?>()
        {
            data = new ListGenreResponse(data),
            Message = "data fetch successfully",
            Status = "200"
        };
    }
}
