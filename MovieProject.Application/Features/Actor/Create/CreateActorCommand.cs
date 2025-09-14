using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieProject.Application.Features.Actor;

public class CreateActorCommand : IRequest<ResponseModel<string>>
{
    [Required]
    public string Name { set; get; }
    [Required]
    public DateTime BirthDate { set; get; }
    [Required]
    public string Nationality { set; get; }

    public Actors ToDomainEntity()
    {
        return new Actors
        {
            Id = Guid.NewGuid().ToString(),
            Name = this.Name,
            BirthDate = this.BirthDate.ToShortDateString(),
            Nationality = this.Nationality,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
}
