namespace TinyServices.API.NewsMagazine.Dto;
public class NewsCommentDto
{
    public Guid NewsUserId { get; set; }
    public string Body { get; set; }
    public Guid Id { get; set; }
    public List<NewsLikeDto> Likes {get; set;}
}
