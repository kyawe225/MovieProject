using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.Actor;

public class UpdateActorCommand : IRequest<ResponseModel<Unit?>>
{
    public string? Id { set; get; }

    public string Name { set; get; }
    public DateTime BirthDate { set; get; }
    public string Nationality { set; get; }

    public Actors ToDomainEntity()
    {
        return new Actors
        {
            Name = this.Name,
            BirthDate = this.BirthDate.ToShortDateString(),
            Nationality = this.Nationality
        };
    }
}
