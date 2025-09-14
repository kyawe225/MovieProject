using System;
using Mediator;
using MovieProject.Application.Features.Actor;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Reviews;

public class DetailReviewCommand : IRequest<ResponseModel<ListReviewResponse?>>
{
    public string Id { set; get; }

    public DetailReviewCommand(string Id)
    {
        this.Id = Id;
    }
}
