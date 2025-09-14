using System;
using Microsoft.EntityFrameworkCore;

namespace MovieProject.Core.Services;

public interface IDatabaseService
{
    public DbSet<T> GetDbSet<T>() where T : class;
    public int SaveChanges();
    public Task<int> SaveChangesAsync(CancellationToken token = default);
}
