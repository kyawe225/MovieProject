using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Actor;

public class ListActorQuery: IRequest<ResponseModel<List<ListActorResponse>>>
{

}


