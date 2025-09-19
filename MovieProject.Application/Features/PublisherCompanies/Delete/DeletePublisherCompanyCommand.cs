using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.PublisherCompanies
    ;

public class DeletePublisherCompanyCommand : IRequest<ResponseModel<Unit?>>
{
    public string Id { set; get; }
    public DeletePublisherCompanyCommand(string Id)
    {
        this.Id = Id;
    }
}
