using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Reviews;

public class DeleteReviewHandler(ICrudRepository<Review, Object> _repository) : IRequestHandler<DeleteReviewCommand, ResponseModel<Unit?>>
{
    public async ValueTask<ResponseModel<Unit?>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
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
        var response = await _repository.delete(request.Id, cancellationToken);
        if (response == false)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Error in deleting Review",
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
