using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Application.Features.Genres;

public class DeleteReviewHandler(ICrudRepository<Genre, Object> _repository) : IRequestHandler<DeleteGenreCommand, ResponseModel<Unit?>>
{
    public async ValueTask<ResponseModel<Unit?>> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var actor = _repository.getDetail(request.Id);
        if (actor == null)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Genre Not Found",
                Status = "404"
            };
        }
        var response = await _repository.delete(request.Id, cancellationToken);
        if (response == false)
        {
            return new ResponseModel<Unit?>
            {
                Message = "Error in deleting Genre",
                Status = "500"
            };
        }
        return new ResponseModel<Unit?>
        {
            Message = "Deleted Genre Successfully",
            Status = "200"
        };
    }
}
