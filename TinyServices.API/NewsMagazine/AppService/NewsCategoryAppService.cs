using TinyServices.API.NewsMagazine.Model;
using TinyServices.API.Repository;

namespace TinyServices.API.NewsMagazine.AppService;
public class NewsCategoryAppService
{

    private readonly TinyServicesDbContext dbContext;

    public NewsCategoryAppService(TinyServicesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<NewsCategory> Create(string name)
    {
        var category = new NewsCategory(name);
        await dbContext.NewsCategories.AddAsync(category);
        await dbContext.SaveChangesAsync();
        return category;
    }
}
