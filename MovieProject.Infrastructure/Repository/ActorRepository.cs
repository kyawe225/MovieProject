using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Infrastructure.Repository;

public class ActorRepository(IDatabaseService service) : ICrudRepository<Actors, Object>
{
    public async Task<bool> delete(string Id, CancellationToken token = default)
    {
        var actor = service.GetDbSet<Actors>().FirstOrDefault(p => p.Id == Id);
        if (actor == null) {
            return false;
        }
        service.GetDbSet<Actors>().Remove(actor);
        await service.SaveChangesAsync(token);
        return true;
    }

    public Actors? getDetail(string Id)
    {
        var actor = service.GetDbSet<Actors>().AsNoTracking().FirstOrDefault(p => p.Id == Id);
        if (actor == null) {
            return null;
        }
        return actor;
    }

    public async Task<List<Actors>> getList(object searchParams, CancellationToken token = default)
    {
        return await service.GetDbSet<Actors>().AsNoTracking().OrderByDescending(d=> d.CreatedAt).ToListAsync(token);
    }

    public async Task<bool> save(Actors obj, CancellationToken token = default)
    {
        service.GetDbSet<Actors>().Add(obj);
        await service.SaveChangesAsync(token);
        return true;
    }

    public async Task<bool> update(string Id, Actors obj, CancellationToken token = default)
    {
        var actor = service.GetDbSet<Actors>().FirstOrDefault(p => p.Id == Id);
        if (actor == null)
            return false;
        actor.Name = obj.Name;
        actor.BirthDate = obj.BirthDate;
        actor.Nationality = obj.Nationality;
        actor.UpdatedAt = DateTime.UtcNow;
        service.GetDbSet<Actors>().Update(actor);
        await service.SaveChangesAsync(token);
        return true;
    }
}
