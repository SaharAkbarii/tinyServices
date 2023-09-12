namespace TinyServices.API.Linkedin.Dto;
public class CommentDto
{
    public Guid Id { get; set; }
    public Guid LinkedinPostId { get; set; }
    public Guid LinkedinUserId { get; set; }
    public string Body { get; set; }
}
