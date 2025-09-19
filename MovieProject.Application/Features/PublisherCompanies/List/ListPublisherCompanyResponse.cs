using MovieProject.Core.Entity;
using System;
using System.Diagnostics.Metrics;

namespace MovieProject.Application.Features.PublisherCompanies;

public class ListPublisherCompanyResponse
{
    public string Id { set; get; }
    public string Name { set; get; }
    public string Country { set; get; }
    public string FoundedYear { set; get; }
    public string Website { set; get; }
    public DateTime CreatedAt { set; get; }
    public DateTime UpdatedAt { set; get; }

    public ListPublisherCompanyResponse(PublisherCompany entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Country = entity.Country;
        FoundedYear = entity.FoundedYear;
        Website = entity.Website;
        CreatedAt = entity.CreatedAt;
        UpdatedAt = entity.UpdatedAt;
    }
}
