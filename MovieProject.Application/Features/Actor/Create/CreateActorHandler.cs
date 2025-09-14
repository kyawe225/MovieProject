using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Actor;

public class CreateActorHandler(ICrudRepository<Actors, Object> repository) : IRequestHandler<CreateActorCommand, ResponseModel<string>>
{
    public async ValueTask<ResponseModel<string>> Handle(CreateActorCommand request, CancellationToken cancellationToken)
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
