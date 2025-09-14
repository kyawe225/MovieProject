using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Director;

public class CreateActorHandler(ICrudRepository<Directors, Object> repository) : IRequestHandler<CreateDirectorCommand, ResponseModel<string>>
{
    public async ValueTask<ResponseModel<string>> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
    {
        var director = request.ToDomainEntity();
        var result = await repository.save(director, cancellationToken);
        if (!result)
        {
            return new ResponseModel<string>()
            {
                data = "BYE BYE",
                Message = "BB",
                Status = "400"
            };
        }
        return new ResponseModel<string>()
        {
            data = "Adddda added",
            Message = "Adda added",
            Status = "200"
        };
    }
}
