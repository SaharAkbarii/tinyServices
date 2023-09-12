namespace TinyServices.API.LinkService.Model;
public class OneTimeLink: Entity
{
    public OneTimeLink(string text, string token)
    {
        Text = text;
        Token = token;
    }
    public string Text { get; set; }
    public string Token { get; set; }
    public bool IsVisited { get; set; }

    public void Visit()
    {
        IsVisited = true;
    }
}
