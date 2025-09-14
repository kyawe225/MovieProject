using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;

namespace MovieProject.Infrastructure.Repository;

public class ReviewRepository(IDatabaseService service) : ICrudRepository<Review, Object>
{
    public async Task<bool> delete(string Id, CancellationToken token = default)
    {
        var genre = service.GetDbSet<Review>().FirstOrDefault(p => p.Id == Id);
        if (genre == null) {
            return false;
        }
        service.GetDbSet<Review>().Remove(genre);
        await service.SaveChangesAsync(token);
        return true;
    }

    public Review? getDetail(string Id)
    {
        var review = service.GetDbSet<Review>().AsNoTracking().FirstOrDefault(p => p.Id == Id);
        if (review == null) {
            return null;
        }
        return review;
    }

    public async Task<List<Review>> getList(object searchParams, CancellationToken token = default)
    {
        return await service.GetDbSet<Review>().AsNoTracking().OrderByDescending(d=> d.CreatedAt).ToListAsync(token);
    }

    public async Task<bool> save(Review obj, CancellationToken token = default)
    {
        service.GetDbSet<Review>().Add(obj);
        await service.SaveChangesAsync(token);
        return true;
    }

    public async Task<bool> update(string Id, Review obj, CancellationToken token = default)
    {
        var review = service.GetDbSet<Review>().FirstOrDefault(p => p.Id == Id);
        if (review == null)
            return false;
        review.Comment = obj.Comment;
        review.Rating = obj.Rating;
        review.UpdatedAt = DateTime.UtcNow;
        service.GetDbSet<Review>().Update(review);
        await service.SaveChangesAsync(token);
        return true;
    }
}
