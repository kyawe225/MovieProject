using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Seasons;

public class UpdateSeasonHandler(ICrudRepository<Season, Object> _repository) : IRequestHandler<UpdateSeasonCommand, ResponseModel<Unit?>>
{
    public async ValueTask<ResponseModel<Unit?>> Handle(UpdateSeasonCommand request, CancellationToken cancellationToken)
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
        var response = await _repository.update(request.Id, request.ToDomainEntity(), cancellationToken);
        if (response == false)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Error in updating Season",
                Status = "500"
            };
        }
        return new ResponseModel<Unit?>
        {
            Message = "Updated Season Successfully",
            Status = "200"
        };
    }
}
