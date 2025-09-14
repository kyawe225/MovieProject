using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Infrastructure.Repository;

public class GenreRepository(IDatabaseService service) : ICrudRepository<Genre, Object>
{
    public async Task<bool> delete(string Id, CancellationToken token = default)
    {
        var genre = service.GetDbSet<Genre>().FirstOrDefault(p => p.Id == Id);
        if (genre == null) {
            return false;
        }
        service.GetDbSet<Genre>().Remove(genre);
        await service.SaveChangesAsync(token);
        return true;
    }

    public Genre? getDetail(string Id)
    {
        var genre = service.GetDbSet<Genre>().AsNoTracking().FirstOrDefault(p => p.Id == Id);
        if (genre == null) {
            return null;
        }
        return genre;
    }

    public async Task<List<Genre>> getList(object searchParams, CancellationToken token = default)
    {
        return await service.GetDbSet<Genre>().AsNoTracking().OrderByDescending(d=> d.CreatedAt).ToListAsync(token);
    }

    public async Task<bool> save(Genre obj, CancellationToken token = default)
    {
        service.GetDbSet<Genre>().Add(obj);
        await service.SaveChangesAsync(token);
        return true;
    }

    public async Task<bool> update(string Id, Genre obj, CancellationToken token = default)
    {
        var genre = service.GetDbSet<Genre>().FirstOrDefault(p => p.Id == Id);
        if (genre == null)
            return false;
        genre.Name = obj.Name;
        genre.Description = obj.Description;
        genre.UpdatedAt = DateTime.UtcNow;
        service.GetDbSet<Genre>().Update(genre);
        await service.SaveChangesAsync(token);
        return true;
    }
}
