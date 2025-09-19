using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.PublisherCompanies;

public class DetailReviewHandler(ICrudRepository<PublisherCompany, Object> _repository) : IRequestHandler<DetailPublisherCompanyCommand, ResponseModel<ListPublisherCompanyResponse?>>
{
    public async ValueTask<ResponseModel<ListPublisherCompanyResponse?>> Handle(DetailPublisherCompanyCommand request, CancellationToken cancellationToken)
    {
        var data = await Task.Run(() => _repository.getDetail(request.Id),cancellationToken);
        if (data == null)
        {
            return new ResponseModel<ListPublisherCompanyResponse?>()
            {
                data = null,
                Message = "data not found",
                Status = "404"
            };
        }
        return new ResponseModel<ListPublisherCompanyResponse?>()
        {
            data = new ListPublisherCompanyResponse(data),
            Message = "data fetch successfully",
            Status = "200"
        };
    }
}
