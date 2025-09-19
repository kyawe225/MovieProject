using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.PublisherCompanies;

public class UpdateReviewHandler(ICrudRepository<PublisherCompany, Object> _repository) : IRequestHandler<UpdatePublisherCompanyCommand, ResponseModel<Unit?>>
{
    public async ValueTask<ResponseModel<Unit?>> Handle(UpdatePublisherCompanyCommand request, CancellationToken cancellationToken)
    {
        var actor = _repository.getDetail(request.Id);
        if (actor == null)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Gemre Not Found",
                Status = "404"
            };
        }
        var response = await _repository.update(request.Id, request.ToDomainEntity(), cancellationToken);
        if (response == false)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Error in updating Genre",
                Status = "500"
            };
        }
        return new ResponseModel<Unit?>
        {
            Message = "Updated Genre Successfully",
            Status = "200"
        };
    }
}
