using System.Web;
using TinyServices.API.LinkService.Model;
using TinyServices.API.Repository;

namespace TinyServices.API.LinkService.AppServices;

public class DeepLinkService
{
    private readonly TinyServicesDbContext dbContext;
    private readonly IConfiguration configuration;
    public DeepLinkService(TinyServicesDbContext dbContext, IConfiguration configuration)
    {
        this.dbContext = dbContext;
        this.configuration = configuration;
    }

    public string Generate(string defaultRoute, string iosLink, string androidLink, string desktopLink, DateTimeOffset? deadLine)
    {
        var token = GenerateToken();

        var deepLink = new DeepLink(defaultRoute, iosLink, androidLink, desktopLink, token);
        var shortenLink = configuration.GetValue<string>("DeepLinkUrl") + token;

        if (deadLine.HasValue)
            deepLink.DeadLine = deadLine;

        dbContext.DeepLinks.Add(deepLink);
        dbContext.SaveChanges();

        return shortenLink;
    }

    public string Resolve(string url, string device)
    {
        url = HttpUtility.UrlDecode(url);
        var uri = new Uri(url);
        var token = new string(uri.AbsolutePath.Skip(1).ToArray());
        var deepLink = dbContext.DeepLinks
            .FirstOrDefault(x => x.Token == token)??
            throw new ArgumentException("The link not found.");

        CheckLinkExpiration(deepLink);

        switch (device.ToLower())
        {
            case "ios":
                return deepLink.IosLink;

            case "android":
                return deepLink.AndroidLink;

            case "desktop":
                return deepLink.DesktopLink;

            default:
                throw new Exception("You can just choose one of this: Ios, Android, Desktop");
        }
    }

    private string GenerateToken()
    {
        var random = new Random();
        var chars = "abcdefghijklmnopqrstuvwxyz0123456789";

        for (int i = 0; i < 5; i++)
        {
            var token = new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(5).ToArray());
            if (!dbContext.ShortLinks.Any(x => x.Token == token))
            {
                return token;
            }
        }
        throw new Exception("An error occurred during generating the link");
    }

        private void CheckLinkExpiration(DeepLink link)
    {
        if (link.DeadLine.HasValue && link.DeadLine < DateTimeOffset.Now)
            throw new Exception("The link has been expired.");
    }
}
