using System;
using Microsoft.Extensions.DependencyInjection;

namespace MovieProject.Application.Extensions;

public static class MediatorExtension
{
    public static void RegisterMediator(this IServiceCollection services)
    {
        services.AddMediator(option =>
        {
            option.ServiceLifetime = ServiceLifetime.Scoped;
        });
    }
}
