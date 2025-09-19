using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Seasons;

public class DeleteSeasonHandler(ICrudRepository<Season, Object> _repository) : IRequestHandler<DeleteSeasonCommand, ResponseModel<Unit?>>
{
    public async ValueTask<ResponseModel<Unit?>> Handle(DeleteSeasonCommand request, CancellationToken cancellationToken)
    {
        var actor = _repository.getDetail(request.Id);
        if (actor == null)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Season Not Found",
                Status = "404"
            };
        }
        var response = await _repository.delete(request.Id, cancellationToken);
        if (response == false)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Error in deleting Season",
                Status = "500"
            };
        }
        return new ResponseModel<Unit?>
        {
            Message = "Deleted Genre Successfully",
            Status = "200"
        };
    }
}
