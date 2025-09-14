using System;
using System.ComponentModel.DataAnnotations;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.Genres;

public class CreateGenreCommand : IRequest<ResponseModel<string>>
{
    [Required]
    public string Name { set; get; }
    [Required]
    public string Description { set; get; }

    public Genre ToDomainEntity()
    {
        return new Genre
        {
            Id = Guid.NewGuid().ToString(),
            Name = this.Name,
            Description = this.Description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
}
