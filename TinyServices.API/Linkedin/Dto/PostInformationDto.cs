namespace TinyServices.API.Linkedin.Dto;

public class PostInformationDto
{
    public Guid Id { get; set; }
    public LinkedinUserInformationDto PostedBy { get; set; }
    public DateTimeOffset PostedAt { get; set; }
    public int Likes { get; set; }
    public List<LinkedinUserInformationDto> Commenters { get; set; }
    public string Description { get; set; }
    public List<string>? ImageUrls { get; set; }
}

