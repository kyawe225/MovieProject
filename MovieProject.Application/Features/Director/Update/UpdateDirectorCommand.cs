using System;
using System.ComponentModel.DataAnnotations;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.Director;

public class UpdateDirectorCommand : IRequest<ResponseModel<Unit?>>
{
    public string? Id { set; get; }

    public string Name { set; get; }
    [Required]
    public DateTime? BirthDate { set; get; }
    [Required]
    public DateTime? JoinedDate { set; get; }

    public Directors ToDomainEntity()
    {
        return new Directors
        {
            Name = this.Name,
            BirthDate = this.BirthDate.Value.ToShortDateString(),
            JoinedDate = this.JoinedDate.Value.ToUniversalTime(),
        };
    }
}
