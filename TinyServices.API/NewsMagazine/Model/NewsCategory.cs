using TinyServices.API.Linkedin.Model;
using TinyServices.API.LinkService.Model;

namespace TinyServices.API.NewsMagazine.Model;

public class NewsCategory : Entity
{
    protected NewsCategory()
    {
    }
    public NewsCategory(string name)
    {
        Name = name;
    }
    public string Name { get; set; }

}

