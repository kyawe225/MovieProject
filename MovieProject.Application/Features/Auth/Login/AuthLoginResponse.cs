using MovieProject.Core.Entity;
using MovieProject.Handler;
using System;

namespace MovieProject.Application.Features.Auth;

public class AuthLoginResponse
{
    public TokenResult AccessToken { set; get; }
    public TokenResult RefreshToken { set; get; }
}
