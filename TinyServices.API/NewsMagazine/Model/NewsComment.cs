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
    private List<NewsLike<NewsComment>> likes;
    private List<NewsDisLike<NewsComment>> disLikes;
    public News News { get; set; }
    public NewsUser NewsUser { get; set; }
    public string Body { get; set; }
    public List<NewsLike<NewsComment>> Likes { get
        {
            if (likes == null)
                likes = new List<NewsLike<NewsComment>>();
            return likes;
        }
        set => likes = value;}
    public List<NewsDisLike<NewsComment>> DisLikes { get
        {
            if (disLikes == null)
                disLikes = new List<NewsDisLike<NewsComment>>();
            return disLikes;
        }
        set => disLikes = value;}
}


