using System;
using Mediator;
using MovieProject.Application.Features.Actor;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Actor;

public class DetailActorHandler(ICrudRepository<Actors, Object> _repository) : IRequestHandler<DetailActorCommand, ResponseModel<ListActorResponse?>>
{
    public async ValueTask<ResponseModel<ListActorResponse?>> Handle(DetailActorCommand request, CancellationToken cancellationToken)
    {
        var data = await Task.Run(() => _repository.getDetail(request.Id),cancellationToken);
        if (data == null)
        {
            return new ResponseModel<ListActorResponse?>()
            {
                data = null,
                Message = "data not found",
                Status = "404"
            };
        }
        return new ResponseModel<ListActorResponse?>()
        {
            data = new ListActorResponse(data),
            Message = "data fetch successfully",
            Status = "200"
        };
    }
}
