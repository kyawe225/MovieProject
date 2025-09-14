using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Reviews;

public class UpdateReviewHandler(ICrudRepository<Review, Object> _repository) : IRequestHandler<UpdateReviewCommand, ResponseModel<Unit?>>
{
    public async ValueTask<ResponseModel<Unit?>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var actor = _repository.getDetail(request.Id);
        if (actor == null)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Review Not Found",
                Status = "404"
            };
        }
        var response = await _repository.update(request.Id, request.ToDomainEntity(), cancellationToken);
        if (response == false)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Error in updating Review",
                Status = "500"
            };
        }
        return new ResponseModel<Unit?>
        {
            Message = "Updated Review Successfully",
            Status = "200"
        };
    }
}
