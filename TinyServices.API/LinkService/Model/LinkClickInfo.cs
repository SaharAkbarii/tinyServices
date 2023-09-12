namespace TinyServices.API.LinkService.Model;
public class LinkClickInfo: Entity
{
    public LinkClickInfo(string token)
    {
        Token = token;
        ClickedAt = DateTimeOffset.UtcNow;
        Id = Guid.NewGuid();
    }
    public string Token { get; set; }
    public DateTimeOffset ClickedAt { get; set; }
}
