using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Reviews;

public class DetailReviewHandler(ICrudRepository<Review, Object> _repository) : IRequestHandler<DetailReviewCommand, ResponseModel<ListReviewResponse?>>
{
    public async ValueTask<ResponseModel<ListReviewResponse?>> Handle(DetailReviewCommand request, CancellationToken cancellationToken)
    {
        var data = await Task.Run(() => _repository.getDetail(request.Id),cancellationToken);
        if (data == null)
        {
            return new ResponseModel<ListReviewResponse?>()
            {
                data = null,
                Message = "data not found",
                Status = "404"
            };
        }
        return new ResponseModel<ListReviewResponse?>()
        {
            data = new ListReviewResponse(data),
            Message = "data fetch successfully",
            Status = "200"
        };
    }
}
