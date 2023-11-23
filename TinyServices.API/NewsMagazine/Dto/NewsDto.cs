using TinyServices.API.Divar.Dto;

namespace TinyServices.API.NewsMagazine.Dto;
public class NewsDto
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? PublishAt { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public StatusDto Status { get; set; }
    public long NewsNumber { get; set; }
    public List<NewsLikeDto>? Likes { get; set; }
    public List<NewsCommentDto>? Comments { get; set; }
    public List<NewsDisLikeDto>? DisLikes { get; set; }
    public List<NewsCategoryContainerDto>? NewsCategories {get; set;}
}

public enum StatusDto
{
    draft,
    publish,
    archive,
}