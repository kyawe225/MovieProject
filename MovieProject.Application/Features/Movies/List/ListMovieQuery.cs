using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Movies;

public class ListMovieQuery: IRequest<ResponseModel<List<ListMovieResponse>>>
{

}


