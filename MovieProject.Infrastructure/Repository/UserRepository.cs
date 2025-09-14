using System;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Core.Entity;
using MovieProject.Core.Services;
using MovieProject.Infrastructure.Handler;

namespace MovieProject.Infrastructure.Repository;

public class UserRepository(IDatabaseService service, IPasswordHandler passwordHandler) : ICrudRepository<User, Object>, IAuthRepository
{
    public async Task<bool> delete(string Id, CancellationToken token = default)
    {
        var genre = service.GetDbSet<User>().FirstOrDefault(p => p.Id == Id);
        if (genre == null)
        {
            return false;
        }
        service.GetDbSet<User>().Remove(genre);
        await service.SaveChangesAsync(token);
        return true;
    }

    public User? getDetail(string Id)
    {
        var User = service.GetDbSet<User>().AsNoTracking().FirstOrDefault(p => p.Id == Id);
        if (User == null)
        {
            return null;
        }
        return User;
    }

    public async Task<List<User>> getList(object searchParams, CancellationToken token = default)
    {
        return await service.GetDbSet<User>().AsNoTracking().OrderByDescending(d => d.CreatedAt).ToListAsync(token);
    }

    public async Task<bool> save(User obj, CancellationToken token = default)
    {
        service.GetDbSet<User>().Add(obj);
        await service.SaveChangesAsync(token);
        return true;
    }

    public async Task<bool> update(string Id, User obj, CancellationToken token = default)
    {
        //    var User = service.GetDbSet<User>().FirstOrDefault(p => p.Id == Id);
        //    if (User == null)
        //        return false;
        //    User.Comment = obj.Comment;
        //    User.Rating = obj.Rating;
        //    User.UpdatedAt = DateTime.UtcNow;
        //    service.GetDbSet<User>().Update(User);
        //    await service.SaveChangesAsync(token);
        //    return true;
        throw new NotImplementedException();
    }

    public async Task<User> Login(string Email, string Password)
    {
        User? user = await service.GetDbSet<User>().FirstOrDefaultAsync(p=> p.Email == Email);
        if (user == null || !passwordHandler.Verify(user?.PasswordHash ?? "",Password, user?.PasswordSalt ?? ""))
        {
            return null;
        }
        return user;
    }
}
