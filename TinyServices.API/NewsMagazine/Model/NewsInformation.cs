namespace TinyServices.API.NewsMagazine.Model;

public class NewsInformation
{
    public Guid Id { get; set; }
    public int Likes { get; set; }
    public List<NewsCommentInformation> Comments { get; set; }
    public int DisLikes { get; set; }
    public DateTimeOffset? PublishAt { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public long NewsNumber { get; set; }
    public int ViewCount {get; set;}
}
