using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Linkedin.Model;

public class PostInformation
{
    public Guid Id { get; set; }
    public LinkedinUserInformation PostedBy { get; set; }
    public DateTimeOffset PostedAt { get; set; }
    public int Likes { get; set; }
    public List<LinkedinUserInformation> Commenters { get; set; }
    public string Description { get; set; }
    public List<string>? ImageUrls { get; set; }
}

