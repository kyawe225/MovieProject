using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Infrastructure.Repository;

public class SeasonRepository(IDatabaseService service) : ICrudRepository<Season, Object>
{
    public async Task<bool> delete(string Id, CancellationToken token = default)
    {
        var entity = service.GetDbSet<Season>().FirstOrDefault(p => p.Id == Id);
        if (entity == null) {
            return false;
        }
        service.GetDbSet<Season>().Remove(entity);
        await service.SaveChangesAsync(token);
        return true;
    }

    public Season? getDetail(string Id)
    {
        var entity = service.GetDbSet<Season>().AsNoTracking().FirstOrDefault(p => p.Id == Id);
        if (entity == null) {
            return null;
        }
        return entity;
    }

    public async Task<List<Season>> getList(object searchParams, CancellationToken token = default)
    {
        return await service.GetDbSet<Season>().AsNoTracking().OrderByDescending(d=> d.CreatedAt).ToListAsync(token);
    }

    public async Task<bool> save(Season obj, CancellationToken token = default)
    {
        service.GetDbSet<Season>().Add(obj);
        await service.SaveChangesAsync(token);
        return true;
    }

    public async Task<bool> update(string Id, Season obj, CancellationToken token = default)
    {
        var entity = service.GetDbSet<Season>().FirstOrDefault(p => p.Id == Id);
        if (entity == null)
            return false;
        //entity.Name = obj.Name;
        //entity.Description = obj.Description;
        entity.UpdatedAt = DateTime.UtcNow;
        service.GetDbSet<Season>().Update(entity);
        await service.SaveChangesAsync(token);
        return true;
    }
}
