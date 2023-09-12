using Microsoft.EntityFrameworkCore;
using TinyServices.API.Divar.Model;
using TinyServices.API.Repository;

namespace TinyServices.API.Divar.AppService;
public class CategoryAppService
{
    private readonly TinyServicesDbContext dbContext;

    public CategoryAppService(TinyServicesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Category Create(string name)
    {
        var category = new Category(name);
        
        dbContext.Categories.Add(category);
        dbContext.SaveChanges();
        return category;
    }

    public Category AddProperty (List<AddPropertyRequest> requests, Guid categoryId)
    {
        var category = dbContext.Categories
            .Include(x=> x.Properties)
            .FirstOrDefault(x=> x.Id == categoryId);
    
        if(category!= null)
        {
            var property= requests.Select(x=> new CategoryProperty(x.Title, x.IsMandatory, category));
            if(category.Properties.Any(x=> property.Any(y=> y.Title==x.Title)))
                throw new Exception("Property title has already saved");

            dbContext.CategoryProperties.AddRange(property);
            dbContext.SaveChanges();
            return category;
        }
        else
            throw new Exception ("category not found!");
    }


    public SearchResult<Category> GetAll(int count, int offset)
    {
        IQueryable<Category> query = dbContext.Categories.AsNoTracking();

        var Categories = query
            .Include(x=> x.Properties)
            .Skip(offset)
            .Take(count)
            .ToList();

        var totalCount = query.Count();

        var searchResult = new SearchResult<Category>(Categories, totalCount);
        return searchResult;
    }
    public Category Search(Guid id)
    {
        var category = dbContext.Categories
            .Include(X=> X.Properties)
            .FirstOrDefault(x => x.Id == id);

        if (category != null)
            return category;
        else
            throw new Exception("Category not found.");
    }
}

public class AddPropertyRequest
{
    public AddPropertyRequest(string title, bool isMandatory)
    {
        Title = title;
        IsMandatory = isMandatory;
    }

    public string Title { get; set; }
    public bool IsMandatory { get; set; }
}