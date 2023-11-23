namespace TinyServices.API.NewsMagazine.Dto;
public class NewsInformationDto
{
    public Guid Id { get; set; }
    public int Likes { get; set; }
    public List<NewsCommentInformationDto> Comments { get; set; }
    public int DisLikes { get; set; }
    public DateTimeOffset? PublishAt { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public long NewsNumber { get; set; }
    public int ViewCount {get; set;}
}
