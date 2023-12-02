using TinyServices.API.LinkService.Model;

namespace TinyServices.API.NewsMagazine.Model;

public class NewsComment<TEntity> : Entity
{
    protected NewsComment()
    {

    }
    public NewsComment(TEntity commentEntity, NewsUser newsUser, string body)
    {
        CommentEntity = commentEntity;
        NewsUser = newsUser;
        Body = body;
    }
    private List<NewsLike<NewsComment<News>>> likes;
    private List<NewsDisLike<NewsComment<News>>> disLikes;
    private List<NewsComment<NewsComment<News>>> replies;
    public TEntity CommentEntity { get; set; }
    public NewsUser NewsUser { get; set; }
    public string Body { get; set; }
    public List<NewsLike<NewsComment<News>>> Likes
    {
        get
        {
            if (likes == null)
                likes = new List<NewsLike<NewsComment<News>>>();
            return likes;
        }
        set => likes = value;
    }
    public List<NewsDisLike<NewsComment<News>>> DisLikes
    {
        get
        {
            if (disLikes == null)
                disLikes = new List<NewsDisLike<NewsComment<News>>>();
            return disLikes;
        }
        set => disLikes = value;
    }
    public List<NewsComment<NewsComment<News>>> Replies
    {
        get
        {
            if (replies == null)
                replies = new List<NewsComment<NewsComment<News>>>();
            return replies;
        }
            set => replies = value;
        }
}



