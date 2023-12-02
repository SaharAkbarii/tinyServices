using TinyServices.API.LinkService.Model;

namespace TinyServices.API.NewsMagazine.Model;
public class News : Entity
{
    protected News()
    {

    }
    public News(string title, string body)
    {
        Title = title;
        Body = body;
        Status = Status.Draft;
    }
    private List<NewsLike<News>> likes;
    private List<NewsComment> comments;
    private List<NewsDisLike<News>> disLikes;
    private List<NewsCategoryContainer> newsCategories;
    public DateTimeOffset? PublishAt { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public Status Status { get; private set; }
    public long NewsNumber { get; set; }
    public List<NewsLike<News>> Likes
    {
        get
        {
            if (likes == null)
                likes = new List<NewsLike<News>>();
            return likes;
        }
        set => likes = value;
    }
    public List<NewsComment> Comments
    {
        get
        {
            if (comments == null)
                comments = new List<NewsComment>();
            return comments;
        }
        set => comments = value;
    }
    public List<NewsDisLike<News>> DisLikes
    {
        get
        {
            if (disLikes == null)
                disLikes = new List<NewsDisLike<News>>();
            return disLikes;
        }
        set => disLikes = value;
    }
    public List<NewsCategoryContainer> NewsCategories
    {
        get
        {
            if (newsCategories == null)
                newsCategories = new List<NewsCategoryContainer>();
            return newsCategories;
        }
        set => newsCategories = value;
    }

    public void ChangeStatus(Status newStatus)
    {
        if (newStatus == Status.Publish && Status != Status.Publish)
            PublishAt = DateTimeOffset.UtcNow;

        Status = newStatus;
    }

}



public enum Status
{
    Draft,
    Publish,
    Archive,
}
