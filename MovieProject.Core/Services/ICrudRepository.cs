using System;

namespace MovieProject.Core.Services;

public interface ICrudRepository<T, ListSearchParams>
{
    public Task<List<T>> getList(ListSearchParams searchParams, CancellationToken token = default);
    public T? getDetail(string Id);
    public Task<bool> save(T obj, CancellationToken token = default);
    public Task<bool> update(string Id, T obj, CancellationToken token = default);
    public Task<bool> delete(string Id, CancellationToken token = default);
}
