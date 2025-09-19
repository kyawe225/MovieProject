using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Reviews;

public class ListReviewQuery : IRequest<ResponseModel<List<ListReviewResponse>>>
{
    public string? MovieId { set; get; }
    public string? SeriesId { set; get; }
    public string? EpisodeId { set; get; }
}


