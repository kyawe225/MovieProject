using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Actor;

public class DeleteActorHandler(ICrudRepository<Actors, Object> _repository) : IRequestHandler<DeleteActorCommand, ResponseModel<Unit?>>
{
    public async ValueTask<ResponseModel<Unit?>> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
    {
        var actor = _repository.getDetail(request.Id);
        if (actor == null)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Actor Not Found",
                Status = "404"
            };
        }
        var response = await _repository.delete(request.Id, cancellationToken);
        if (response == false)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Error in deleting Actor",
                Status = "500"
            };
        }
        return new ResponseModel<Unit?>
        {
            Message = "Deleted Actor Successfully",
            Status = "200"
        };
    }
}
