using TinyServices.API.LinkService.Model;

namespace TinyServices.API.NewsMagazine.Model;

public class NewsComment : Entity
{
    protected NewsComment()
    {

    }
    public NewsComment(News news, NewsUser newsUser, string body)
    {
        News = news;
        NewsUser = newsUser;
        Body = body;
    }

    public News News { get; set; }
    public NewsUser NewsUser { get; set; }
    public string Body { get; set; }
    public List<NewsLike<NewsComment>> Likes {get; set;}
}


