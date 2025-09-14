using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.Genres;

public class UpdateGenreCommand : IRequest<ResponseModel<Unit?>>
{
    public string? Id { set; get; }

    public string Name { set; get; }
    public string Description { set; get; }

    public Genre ToDomainEntity()
    {
        return new Genre
        {
            Name = this.Name,
            Description = this.Description,
        };
    }
}
