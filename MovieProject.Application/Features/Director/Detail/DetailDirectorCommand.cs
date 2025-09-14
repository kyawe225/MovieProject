using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Director;

public class DetailDirectorCommand : IRequest<ResponseModel<ListDirectorResponse?>>
{
    public string Id { set; get; }

    public DetailDirectorCommand(string Id)
    {
        this.Id = Id;
    }
}
