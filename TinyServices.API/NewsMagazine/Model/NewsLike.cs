using TinyServices.API.LinkService.Model;

namespace TinyServices.API.NewsMagazine.Model;

public class NewsLike : Entity
{
    protected NewsLike()
    {

    }
    public NewsLike(News newsPost, NewsUser newsUser)
    {
        NewsPost = newsPost;
        NewsUser = newsUser;
    }

    public News NewsPost { get; set; }
    public NewsUser NewsUser { get; set; }
}

