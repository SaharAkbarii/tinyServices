using Microsoft.EntityFrameworkCore;
using TinyServices.API.LinkService.Model;
using User = TinyServices.API.NewsMagazine.Model.NewsUser;

namespace TinyServices.API.NewsMagazine.AppService;

public static class DbContextExtensionMethods
{
    public async static Task <TResult> FindModelAsync<TResult>(this IQueryable<TResult> queryable, Guid id) 
        where TResult : Entity
    {
        var result = await queryable.FirstOrDefaultAsync(x => x.Id == id) ??
            throw new Exception($"{typeof(TResult).Name} with id: {id} not found.");     
        return result;
    } 
}

