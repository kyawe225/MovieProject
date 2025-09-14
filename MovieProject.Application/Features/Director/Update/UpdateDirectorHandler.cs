using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Director;

public class UpdateDirectorHandler(ICrudRepository<Directors, Object> _repository) : IRequestHandler<UpdateDirectorCommand, ResponseModel<Unit?>>
{
    public async ValueTask<ResponseModel<Unit?>> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
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
        var response = await _repository.update(request.Id, request.ToDomainEntity(), cancellationToken);
        if (response == false)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Error in updating Director",
                Status = "500"
            };
        }
        return new ResponseModel<Unit?>
        {
            Message = "Updated Director Successfully",
            Status = "200"
        };
    }
}
