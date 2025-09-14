using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Reviews;

public class ListReviewHandler(ICrudRepository<Review, Object> repository) : IRequestHandler<ListReviewQuery, ResponseModel<List<ListReviewResponse>>>
{
    public async ValueTask<ResponseModel<List<ListReviewResponse>>> Handle(ListReviewQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.getList(request,cancellationToken);
        return new ResponseModel<List<ListReviewResponse>>
        {
            data = list.Select(p => new ListReviewResponse(p)).ToList(),
            Status = "OK",
            Message = "Successfully Fetched"
        };
    }
}
