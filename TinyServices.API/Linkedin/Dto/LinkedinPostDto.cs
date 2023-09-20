namespace TinyServices.API.Linkedin.Dto;
public class LinkedinPostDto
{
    public Guid UserId { get; set; }
    public List<string> ImageUrls { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreatedAt {get; set;}
}
