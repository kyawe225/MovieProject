using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.Director;

public class DeleteDirectorCommand : IRequest<ResponseModel<Unit?>>
{
    public string Id { set; get; }
    public DeleteDirectorCommand(string Id)
    {
        this.Id = Id;
    }
}
