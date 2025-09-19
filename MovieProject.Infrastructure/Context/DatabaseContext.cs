using System;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;
using MovieProject.Infrastructure.Handler;

namespace MovieProject.Infrastructure.Context;

public class DatabaseContext : DbContext , IDatabaseService
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<PublisherCompany> tbl_publishers { set; get; }
    public DbSet<Actors> tbl_actors { set; get; }
    public DbSet<Directors> tbl_directors { set; get; }
    public DbSet<Genre> tbl_categories { set; get; }
    public DbSet<User> tbl_users { set; get; }
    public DbSet<Series> tbl_series { set; get; }
    public DbSet<Season> tbl_seasons { set; get; }
    public DbSet<Episode> tbl_episdes { set; get; }
    public DbSet<Movie> tbl_movies { set; get; }
    public DbSet<Review> tbl_reviews { set; get; }
    public DbSet<WatchList> tbl_watchLists { set; get; }
    public DbSet<Role> tbl_roles { set; get; }

    public DbSet<T> GetDbSet<T>() where T : class {
        return this.Set<T>();
    }

    async Task<int> IDatabaseService.SaveChangesAsync(CancellationToken token)
    {
        return await base.SaveChangesAsync(token);
    }
}
