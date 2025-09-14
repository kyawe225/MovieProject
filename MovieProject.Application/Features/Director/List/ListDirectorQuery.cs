using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Director;

public class ListDirectorQuery: IRequest<ResponseModel<List<ListDirectorResponse>>>
{

}


