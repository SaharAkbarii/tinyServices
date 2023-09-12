using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Divar.Model;

public class Advertisement : Entity
{
    protected Advertisement()
    {

    }
    public Advertisement(Category category, string title, string city, string neighborhood, PhoneNumber phoneNumber, List<PropertyValue> propertyValues, User user)
    {
        Category = category;
        Title = title;
        City = city;
        Neighborhood = neighborhood;
        PhoneNumber = phoneNumber;
        PropertyValues = propertyValues;
        User = user;
        IsApproved = false;
    }

    public Category Category { get; set; }
    public string Title { get; set; }
    public int? Price { get; set; }
    public List<string>? UrlImage { get; set; }
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string? Description { get; set; }
    public List<PropertyValue> PropertyValues { get; set; }
    public User User { get; set; }
    public bool IsApproved { get; set; }
}
