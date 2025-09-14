using System;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;
using MovieProject.Handler;

namespace MovieProject.Application.Features.Auth;

public class AuthLoginHandler(IAuthRepository repository, IJwtHandler handler) : IRequestHandler<AuthLoginCommand, ResponseModel<AuthLoginResponse>>
{
    public async ValueTask<ResponseModel<AuthLoginResponse>> Handle(AuthLoginCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.Login(request.Email, request.Password);
        if(user == null)
        {
            return new ResponseModel<AuthLoginResponse>()
            {
                Message = "Incorrect Email Or Password",
                Status = "400"
            };
        }

        var AuthToken= handler.GenerateToken(user);
        var RefreshToken = handler.GenerateRefreshToken(user);

        return new ResponseModel<AuthLoginResponse>()
        {
            data = new AuthLoginResponse
            {
                AccessToken = AuthToken,
                RefreshToken = RefreshToken
            },
            Message = "Login Successfully",
            Status = "200"
        };
    }
}
