using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Genres;

public class ListGenreQuery: IRequest<ResponseModel<List<ListGenreResponse>>>
{

}


