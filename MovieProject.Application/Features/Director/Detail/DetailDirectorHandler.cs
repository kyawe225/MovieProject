using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Director;

public class DetailDirectorHandler(ICrudRepository<Directors, Object> _repository) : IRequestHandler<DetailDirectorCommand, ResponseModel<ListDirectorResponse?>>
{
    public async ValueTask<ResponseModel<ListDirectorResponse?>> Handle(DetailDirectorCommand request, CancellationToken cancellationToken)
    {
        var data = await Task.Run(() => _repository.getDetail(request.Id),cancellationToken);
        if (data == null)
        {
            return new ResponseModel<ListDirectorResponse?>()
            {
                data = null,
                Message = "data not found",
                Status = "404"
            };
        }
        return new ResponseModel<ListDirectorResponse?>()
        {
            data = new ListDirectorResponse(data),
            Message = "data fetch successfully",
            Status = "200"
        };
    }
}
