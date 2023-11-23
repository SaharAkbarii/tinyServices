using TinyServices.API.LinkService.Model;

namespace TinyServices.API.NewsMagazine.Model;

public class FavoriteCategory : Entity
{
    protected FavoriteCategory()
    {

    }
    public FavoriteCategory(NewsUser user, NewsCategory category)
    {
        User = user;
        Category = category;
        Id = Guid.Empty;
    }

    public NewsUser User { get; set; }
    public NewsCategory Category { get; set; }
}
