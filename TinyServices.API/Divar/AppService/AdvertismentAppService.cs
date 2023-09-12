using Microsoft.EntityFrameworkCore;
using TinyServices.API.Divar.Model;
using TinyServices.API.Repository;

namespace TinyServices.API.Divar.AppService;
public class AdvertisementAppService
{
    private readonly TinyServicesDbContext dbContext;

    public AdvertisementAppService(TinyServicesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Advertisement Create(Guid categoryId,
        string title,
        string city,
        string neighborhood,
        string phoneNumberValue,
        Dictionary<Guid, string> propertyValuesInput,
        Guid userId,
        int? price,
        List<string>? urlImage)
    {
        var phoneNumber = new PhoneNumber(phoneNumberValue);

        var category = dbContext.Categories.Include(x => x.Properties)
            .FirstOrDefault(x => x.Id == categoryId)??
            throw new Exception ($"category with user id : {categoryId} not found!");

        var user = dbContext.Users.FirstOrDefault(x => x.Id == userId)??
            throw new Exception ($"user with user id : {userId} not found!");

        if (category == null)
            throw new Exception("category not found");

        var propertyValues = new List<PropertyValue>();
        foreach (var item in propertyValuesInput)
        {
            var property = category.Properties.FirstOrDefault(x => item.Key == x.Id);
            var propertyValue = new PropertyValue(property, item.Value);
            propertyValues.Add(propertyValue);
        }

        var advertisement = new Advertisement(category, title, city, neighborhood, phoneNumber, propertyValues, user)
        {
            Price = price,
            UrlImage = urlImage
        };
        foreach (var item in category.Properties.Where(x => x.IsMandatory))
        {
            if (!advertisement.PropertyValues.Any(p => p.Property.Id == item.Id))
                throw new Exception($"{item.Title} should have value.");
        }
        
        dbContext.Advertisements.Add(advertisement);
        dbContext.SaveChanges();

        return advertisement;
    }

    public SearchResult<Advertisement> Feed(string city, Guid? categoryId, string? keyWord, int count, int offset)
    {
        var query = dbContext.Advertisements
            .Include(x => x.Category)
            .Where(x => x.City == city)
            .Where(x=> x.IsApproved);

        if (categoryId.HasValue)
            query = query.Where(x => x.Category.Id == categoryId);
        if (keyWord != null)
            query = query.Where(x => x.Title.Contains(keyWord));

        var advertisements = query
            .Include(x => x.Category)
            .ThenInclude(x => x.Properties)
            .Include(x => x.PropertyValues)
            .Include(x => x.User)
            .Skip(offset)
            .Take(count)
            .ToList();

        var totalCount = query.Count();

        var searchResult = new SearchResult<Advertisement>(advertisements, totalCount);
        return searchResult;

    }
    public Advertisement Approve (Guid id)
    {
        var advertisement = dbContext.Advertisements.FirstOrDefault(x=> x.Id == id)??
            throw new Exception ($"advertisement with id {id} not found.");
        advertisement.IsApproved = true;

        dbContext.SaveChanges();
        return advertisement;
    }
}



