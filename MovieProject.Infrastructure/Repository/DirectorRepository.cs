using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Infrastructure.Repository;

public class DirectorRepository(IDatabaseService service) : ICrudRepository<Directors, Object>
{
    public async Task<bool> delete(string Id, CancellationToken token = default)
    {
        var director = service.GetDbSet<Directors>().FirstOrDefault(p => p.Id == Id);
        if (director == null) {
            return false;
        }
        service.GetDbSet<Directors>().Remove(director);
        await service.SaveChangesAsync(token);
        return true;
    }

    public Directors? getDetail(string Id)
    {
        var director = service.GetDbSet<Directors>().AsNoTracking().FirstOrDefault(p => p.Id == Id);
        if (director == null) {
            return null;
        }
        return director;
    }

    public async Task<List<Directors>> getList(object searchParams, CancellationToken token = default)
    {
        return await service.GetDbSet<Directors>().AsNoTracking().OrderByDescending(d=> d.CreatedAt).ToListAsync(token);
    }

    public async Task<bool> save(Directors obj, CancellationToken token = default)
    {
        service.GetDbSet<Directors>().Add(obj);
        await service.SaveChangesAsync(token);
        return true;
    }

    public async Task<bool> update(string Id, Directors obj, CancellationToken token = default)
    {
        var director = service.GetDbSet<Directors>().FirstOrDefault(p => p.Id == Id);
        if (director == null)
            return false;
        director.Name = obj.Name;
        director.BirthDate = obj.BirthDate;
        director.UpdatedAt = DateTime.UtcNow;
        service.GetDbSet<Directors>().Update(director);
        await service.SaveChangesAsync(token);
        return true;
    }
}
