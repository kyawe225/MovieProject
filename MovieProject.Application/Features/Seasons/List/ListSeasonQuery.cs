using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Seasons;

public class ListSeasonQuery: IRequest<ResponseModel<List<ListSeasonResponse>>>
{

}


