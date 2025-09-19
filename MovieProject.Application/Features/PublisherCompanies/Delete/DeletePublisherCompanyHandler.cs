using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.PublisherCompanies;

public class DeleteReviewHandler(ICrudRepository<PublisherCompany, Object> _repository) : IRequestHandler<DeletePublisherCompanyCommand, ResponseModel<Unit?>>
{
    public async ValueTask<ResponseModel<Unit?>> Handle(DeletePublisherCompanyCommand request, CancellationToken cancellationToken)
    {
        var actor = _repository.getDetail(request.Id);
        if (actor == null)
        {
            return new ResponseModel<Unit?>
            {
                Message = "PublisherCompany Not Found",
                Status = "404"
            };
        }
        var response = await _repository.delete(request.Id, cancellationToken);
        if (response == false)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Error in deleting PublisherCompany",
                Status = "500"
            };
        }
        return new ResponseModel<Unit?>
        {
            Message = "Deleted PublisherCompany Successfully",
            Status = "200"
        };
    }
}
