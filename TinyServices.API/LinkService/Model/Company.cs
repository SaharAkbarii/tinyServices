namespace TinyServices.API.LinkService.Model;
public class Company : Entity
{
    public Company(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    public List<ShortLink>? ShortLinks { get; set; }
}
