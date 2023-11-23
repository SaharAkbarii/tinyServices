using TinyServices.API.Divar.Model;
using TinyServices.API.LinkService.Model;

namespace TinyServices.API.NewsMagazine.Model;

public class NewsUser : Entity
{
    protected NewsUser()
    {

    }
    public NewsUser(Email email, string name)
    {
        Email = email;
        Name = name;
    }
    private List<FavoriteCategory> favoriteCategories;

    public Email Email { get; set; }
    public string Name { get; set; }
    public List<FavoriteCategory> FavoriteCategories
    {
        get
        {
            if (favoriteCategories == null)
                favoriteCategories = new List<FavoriteCategory>();
            return favoriteCategories;
        }
        set => favoriteCategories = value;
    }

}
