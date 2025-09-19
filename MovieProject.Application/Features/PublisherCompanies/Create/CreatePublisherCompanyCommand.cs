using System;
using System.ComponentModel.DataAnnotations;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.PublisherCompanies;

public class CreatePublisherCompanyCommand : IRequest<ResponseModel<string>>
{
    [Required]
    public string Name { set; get; }
    [Required]
    public string Country { set; get; }
    [Required]
    public string FoundedYear { set; get; }
    [Required]
    public string Website { set; get; }

    public PublisherCompany ToDomainEntity()
    {
        return new PublisherCompany
        {
            Name = this.Name,
            Country = this.Country,
            FoundedYear = this.FoundedYear,
            Website = this.Website,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
    }
}
