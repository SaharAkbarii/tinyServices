namespace TinyServices.API.LinkService.Model;

public class DeepLink: Entity
{
    public DeepLink(string defaultRoute, string iosLink, string androidLink, string desktopLink, string token)
    {
        DefaultRoute = defaultRoute;
        IosLink = iosLink;
        AndroidLink = androidLink;
        DesktopLink = desktopLink;
        Token = token;
    }

    public string DefaultRoute {get; set;}
    public string IosLink { get; set; }
    public string AndroidLink { get; set; }
    public string DesktopLink { get; set; }
    public string Token { get; set; }
    public DateTimeOffset? DeadLine {get; set;}
}
