using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Director;

public class DeleteActorHandler(ICrudRepository<Directors, Object> _repository) : IRequestHandler<DeleteDirectorCommand, ResponseModel<Unit?>>
{
    public async ValueTask<ResponseModel<Unit?>> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
    {
        var actor = _repository.getDetail(request.Id);
        if (actor == null)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Director Not Found",
                Status = "404"
            };
        }
        var response = await _repository.delete(request.Id, cancellationToken);
        if (response == false)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Error in deleting Director",
                Status = "500"
            };
        }
        return new ResponseModel<Unit?>
        {
            Message = "Deleted Director Successfully",
            Status = "200"
        };
    }
}
