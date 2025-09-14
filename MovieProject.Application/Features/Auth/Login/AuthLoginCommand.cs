using System;
using System.ComponentModel.DataAnnotations;
using Mediator;
using MovieProject.Application.Models;
using MovieProject.Core.Entity;

namespace MovieProject.Application.Features.Auth;

public class AuthLoginCommand : IRequest<ResponseModel<AuthLoginResponse>>
{
    [Required]
    public string Email { set; get; }
    [Required]
    public string Password { set; get; }
}
