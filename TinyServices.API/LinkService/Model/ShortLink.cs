namespace TinyServices.API.LinkService.Model;

public class ShortLink : Entity
{
    protected ShortLink()
    {
    }
    public ShortLink(string mainLink, string token, Company company)
    {
        MainLink = mainLink;
        Token = token;
        Company = company;
    }

    public string MainLink { get; set; }
    public string Token { get; set; }
    public DateTimeOffset? DeadLine {get; set;}
    public Company Company {get; set;}
}
