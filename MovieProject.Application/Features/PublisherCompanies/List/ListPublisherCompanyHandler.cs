using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.PublisherCompanies;

public class ListPublisherCompanyHandler(ICrudRepository<PublisherCompany, Object> repository) : IRequestHandler<ListPublisherCompanyQuery, ResponseModel<List<ListPublisherCompanyResponse>>>
{
    public async ValueTask<ResponseModel<List<ListPublisherCompanyResponse>>> Handle(ListPublisherCompanyQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.getList(request,cancellationToken);
        return new ResponseModel<List<ListPublisherCompanyResponse>>
        {
            data = list.Select(p => new ListPublisherCompanyResponse(p)).ToList(),
            Status = "OK",
            Message = "Successfully Fetched"
        };
    }
}
