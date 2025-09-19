using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;
using System;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace MovieProject.Infrastructure.Repository;

public class PublisherCompanyRepository(IDatabaseService service) : ICrudRepository<PublisherCompany, Object>
{
    public async Task<bool> delete(string Id, CancellationToken token = default)
    {
        var PublisherCompany = service.GetDbSet<PublisherCompany>().FirstOrDefault(p => p.Id == Id);
        if (PublisherCompany == null)
        {
            return false;
        }
        service.GetDbSet<PublisherCompany>().Remove(PublisherCompany);
        await service.SaveChangesAsync(token);
        return true;
    }

    public PublisherCompany? getDetail(string Id)
    {
        var PublisherCompany = service.GetDbSet<PublisherCompany>().AsNoTracking().FirstOrDefault(p => p.Id == Id);
        if (PublisherCompany == null)
        {
            return null;
        }
        return PublisherCompany;
    }

    public async Task<List<PublisherCompany>> getList(object searchParams, CancellationToken token = default)
    {
        return await service.GetDbSet<PublisherCompany>().AsNoTracking().OrderByDescending(d => d.CreatedAt).ToListAsync(token);
    }

    public async Task<bool> save(PublisherCompany obj, CancellationToken token = default)
    {
        service.GetDbSet<PublisherCompany>().Add(obj);
        await service.SaveChangesAsync(token);
        return true;
    }

    public async Task<bool> update(string Id, PublisherCompany obj, CancellationToken token = default)
    {
        var entity = service.GetDbSet<PublisherCompany>().FirstOrDefault(p => p.Id == Id);
        if (entity == null)
            return false;
        entity.Name = obj.Name;
        entity.Name = obj.Name;
        entity.Country = obj.Country;
        entity.FoundedYear = obj.FoundedYear;
        entity.Website = obj.Website;
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        service.GetDbSet<PublisherCompany>().Update(entity);
        await service.SaveChangesAsync(token);
        return true;
    }
}
