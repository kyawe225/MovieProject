using Mediator;
using MovieProject.Application.Features.Actor;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;
using System;

namespace MovieProject.Application.Features.Seasons;

public class CreateSeasonHandler(ICrudRepository<Season, Object> repository) : IRequestHandler<CreateSeasonCommand, ResponseModel<string>>
{
    public async ValueTask<ResponseModel<string>> Handle(CreateSeasonCommand request, CancellationToken cancellationToken)
    {
        var actor = request.ToDomainEntity();
        var result = await repository.save(actor,cancellationToken);
        if (!result)
        {
            return new ResponseModel<string>()
            {
                data = "BYE BYE",
                Message = "BB",
                Status = "NG"
            };
        }
        return new ResponseModel<string>()
        {
            data = "Adddda added",
            Message = "Adda added",
            Status = "OK"
        };
    }
}
