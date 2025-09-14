using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Core.Entity;
using MovieProject.Infrastructure.Context;
using MovieProject.Infrastructure.Handler;

namespace MovieProject.Infrastructure.Extension;

public static class PostgresExtension 
{
    public static void AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgresConnection");
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseNpgsql(connectionString , i => i.MigrationsAssembly("MovieProject")).UseSeeding((context, _) =>
            {
                Role role = new Role()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "admin",
                    Description = "This is pregenerated admin role",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                IPasswordHandler handler = new Argon2PasswordHandler();
                var ans = handler.Hash("password");
                User user = new User()
                {
                    Email = "kyaw@codigo.co",
                    Name = "kyawe",
                    Id = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PasswordHash = ans.PasswordHash,
                    PasswordSalt = ans.Salt,
                    RoleId = role.Id
                };

                context.Set<Role>().Add(role);
                context.Set<User>().Add(user);
                context.SaveChanges();
            });
        });
    }
}
