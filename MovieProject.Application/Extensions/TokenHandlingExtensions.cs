using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MovieProject.Application;
using MovieProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Infrastructure.Extension
{
    public static class TokenHandlingExtensions
    {
        public static void AddJwtBearerTokenHandling(this IServiceCollection service, IConfiguration configuration)
        {
            var issuer = configuration.GetValue<string>("Jwt:Issuer", "");
            var audience = configuration.GetValue<string>("Jwt:Audience", "");
            var authSigningKey = configuration.GetValue<string>("TokenSigningKeys:Authentication", "");
            var refreshSigningKey = configuration.GetValue<string>("TokenSigningKeys:Refresh", "");

            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerChallengeType.AccessToken;
                options.DefaultChallengeScheme = JwtBearerChallengeType.AccessToken;
            })
            .AddJwtBearer(JwtBearerChallengeType.AccessToken, options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSigningKey)),
                    ValidateLifetime = true, // access tokens must expire
                    ClockSkew = TimeSpan.FromMinutes(1),
                    NameClaimType = "access"
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine($"Token validated for: {context.Principal?.Identity?.Name}");
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        Console.WriteLine($"OnChallenge error: {context.Error}, {context.ErrorDescription}");
                        return Task.CompletedTask;
                    }
                };
            })

            // 2) Refresh token scheme (rarely needed — usually validated manually!)
            .AddJwtBearer(JwtBearerChallengeType.RefreshToken, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes((refreshSigningKey))),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,

                    // extra check: only accept tokens with "typ":"refresh"
                    NameClaimType = "refresh"
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine($"Token validated for: {context.Principal?.Identity?.Name}");
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        Console.WriteLine($"OnChallenge error: {context.Error}, {context.ErrorDescription}");
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
