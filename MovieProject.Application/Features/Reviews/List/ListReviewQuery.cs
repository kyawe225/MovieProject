using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Reviews;

public class ListReviewQuery: IRequest<ResponseModel<List<ListReviewResponse>>>
{

}


