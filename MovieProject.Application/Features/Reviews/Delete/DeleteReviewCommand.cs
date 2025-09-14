using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Reviews
    ;

public class DeleteReviewCommand : IRequest<ResponseModel<Unit?>>
{
    public string Id { set; get; }
    public DeleteReviewCommand(string Id)
    {
        this.Id = Id;
    }
}
