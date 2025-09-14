using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Infrastructure.Repository;

public class MovieRepository(IDatabaseService service) : ICrudRepository<Movie, Object>
{
    public async Task<bool> delete(string Id, CancellationToken token = default)
    {
        var director = service.GetDbSet<Movie>().FirstOrDefault(p => p.Id == Id);
        if (director == null) {
            return false;
        }
        service.GetDbSet<Movie>().Remove(director);
        await service.SaveChangesAsync(token);
        return true;
    }

    public Movie? getDetail(string Id)
    {
        var director = service.GetDbSet<Movie>().AsNoTracking().FirstOrDefault(p => p.Id == Id);
        if (director == null) {
            return null;
        }
        return director;
    }

    public async Task<List<Movie>> getList(object searchParams, CancellationToken token = default)
    {
        return await service.GetDbSet<Movie>().AsNoTracking().OrderByDescending(d=> d.CreatedAt).ToListAsync(token);
    }

    public async Task<bool> save(Movie obj, CancellationToken token = default)
    {
        service.GetDbSet<Movie>().Add(obj);
        await service.SaveChangesAsync(token);
        return true;
    }

    public async Task<bool> update(string Id, Movie obj, CancellationToken token = default)
    {
        var movie = service.GetDbSet<Movie>().FirstOrDefault(p => p.Id == Id);
        if (movie == null)
            return false;
        //director.Name = obj.Name;
        //director.BirthDate = obj.BirthDate;
        //director.UpdatedAt = DateTime.UtcNow;
        service.GetDbSet<Movie>().Update(movie);
        await service.SaveChangesAsync(token);
        return true;
    }
}
