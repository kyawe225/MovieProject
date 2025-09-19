using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Seasons;

public class DetailSeasonHandler(ICrudRepository<Season, Object> _repository) : IRequestHandler<DetailSeasonCommand, ResponseModel<ListSeasonResponse?>>
{
    public async ValueTask<ResponseModel<ListSeasonResponse?>> Handle(DetailSeasonCommand request, CancellationToken cancellationToken)
    {
        var data = await Task.Run(() => _repository.getDetail(request.Id),cancellationToken);
        if (data == null)
        {
            return new ResponseModel<ListSeasonResponse?>()
            {
                data = null,
                Message = "data not found",
                Status = "404"
            };
        }
        return new ResponseModel<ListSeasonResponse?>()
        {
            data = new ListSeasonResponse(data),
            Message = "data fetch successfully",
            Status = "200"
        };
    }
}
