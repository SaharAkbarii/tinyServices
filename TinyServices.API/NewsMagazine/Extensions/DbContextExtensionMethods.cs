using TinyServices.API.LinkService.Model;
using User = TinyServices.API.NewsMagazine.Model.NewsUser;

namespace TinyServices.API.NewsMagazine.AppService;

public static class DbContextExtensionMethods
{
    public static User FindUser(this IQueryable<User> queryable, Guid userId)
    {
        var user = queryable.FirstOrDefault(x => x.Id == userId) ??
            throw new Exception($"user with id: {userId} not found.");
        return user;
    }
    public static TResult FindModel<TResult>(this IQueryable<TResult> queryable, Guid id) where TResult : Entity
    {
        var result = queryable.FirstOrDefault(x => x.Id == id) ??
            throw new Exception($"{typeof(TResult).Name} with id: {id} not found.");
        return result;
    } 
}

