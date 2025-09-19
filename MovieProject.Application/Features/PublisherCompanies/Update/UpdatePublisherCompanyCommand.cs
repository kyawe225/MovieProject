using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.PublisherCompanies;

public class UpdatePublisherCompanyCommand : IRequest<ResponseModel<Unit?>>
{
    public string? Id { set; get; }

    public string Name { set; get; }
    public string Country { set; get; }
    public string FoundedYear { set; get; }
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
