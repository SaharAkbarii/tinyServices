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

    public NewsCategory Create(string name)
    {
        var category = new NewsCategory(name);
        dbContext.NewsCategories.Add(category);
        dbContext.SaveChanges();
        return category;
    }
}
