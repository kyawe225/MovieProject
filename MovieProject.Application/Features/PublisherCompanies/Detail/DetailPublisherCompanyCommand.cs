using System;
using Mediator;
using MovieProject.Application.Features.Actor;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.PublisherCompanies;

public class DetailPublisherCompanyCommand : IRequest<ResponseModel<ListPublisherCompanyResponse?>>
{
    public string Id { set; get; }

    public DetailPublisherCompanyCommand(string Id)
    {
        this.Id = Id;
    }
}
