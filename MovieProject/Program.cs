using Microsoft.AspNetCore.Authentication.JwtBearer;
using MovieProject.Application.Extensions;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;
using MovieProject.Handler;
using MovieProject.Infrastructure.Context;
using MovieProject.Infrastructure.Extension;
using MovieProject.Infrastructure.Handler;
using MovieProject.Infrastructure.Repository;
using MovieProject.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHealthChecks();

builder.Services.AddControllers();



//builder.Services.AddSerilog((services, lc) =>
//    lc.WriteTo.Console()
//    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
//    .Enrich.FromLogContext()
//    .Enrich.WithProperty("ApplicationName", services.GetRequiredService<IWebHostEnvironment>().ApplicationName));

AddRepositories(builder.Services);

AddAuthRequiredServices(builder.Services);

builder.Services.AddJwtBearerTokenHandling(builder.Configuration);

builder.Services.RegisterMediator();

builder.Services.AddHttpLogging();

builder.Services.AddPostgres(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<JwtDebugMiddleware>();

app.UseHealthChecks("/health");

app.UseHttpLogging();

app.UseAuthentication();

app.UseAuthorization();

//app.UseSerilogRequestLogging();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();


void AddRepositories(IServiceCollection service)
{
    service.AddScoped<IDatabaseService, DatabaseContext>();
    service.AddScoped<ICrudRepository<Actors, Object>, ActorRepository>();
    service.AddScoped<ICrudRepository<Directors, Object>, DirectorRepository>();
    service.AddScoped<ICrudRepository<Genre, Object>, GenreRepository>();
    service.AddScoped<ICrudRepository<Review, Object>, ReviewRepository>();
    service.AddScoped<ICrudRepository<User, Object>, UserRepository>();
    service.AddScoped<ICrudRepository<Movie, Object>, MovieRepository>();
    service.AddScoped<IAuthRepository, UserRepository>();
}

void AddAuthRequiredServices(IServiceCollection service)
{
    service.AddSingleton<IJwtHandler, JwtHandler>();
    service.AddSingleton<IPasswordHandler, Argon2PasswordHandler>();
}