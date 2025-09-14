using System;
using System.ComponentModel.DataAnnotations;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.Director;

public class CreateDirectorCommand : IRequest<ResponseModel<string>>
{
    [Required]
    public string Name { set; get; }
    [Required]
    public DateTime? BirthDate { set; get; }
    [Required]
    public DateTime? JoinedDate { set; get; }

    public Directors ToDomainEntity()
    {
        return new Directors
        {
            Id = Guid.NewGuid().ToString(),
            Name = this.Name,
            BirthDate = this.BirthDate?.ToShortDateString(),
            JoinedDate = this.JoinedDate.Value.ToUniversalTime(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
}
