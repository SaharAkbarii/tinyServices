using System.Web;
using Microsoft.EntityFrameworkCore;
using TinyServices.API.LinkService.Model;
using TinyServices.API.Repository;

namespace TinyServices.API.LinkService.AppServices;
public class ShortLinkService
{
    private readonly TinyServicesDbContext dbContext;
    private readonly IConfiguration configuration;
    public ShortLinkService(TinyServicesDbContext dbContext, IConfiguration configuration)
    {
        this.dbContext = dbContext;
        this.configuration = configuration;
    }
    public string Generate(string mainLink, DateTimeOffset? deadLine, Guid companyId)
    {
        var token = GenerateToken();
        var company = dbContext.Companies
            .FirstOrDefault(x => x.Id == companyId) ??
            throw new Exception("The company was not found!");

        var shortLink = new ShortLink(mainLink, token, company);

        var shortenLink = configuration.GetValue<string>("ShortLinkUrl") + token;

        if (deadLine.HasValue)
            shortLink.DeadLine = deadLine;

        dbContext.ShortLinks.Add(shortLink);
        dbContext.SaveChanges();

        return shortenLink;
    }

    public string Resolve(string url)
    {
        url = HttpUtility.UrlDecode(url);
        var uri = new Uri(url);
        var token = new string(uri.AbsolutePath.Skip(1).ToArray());
        var shortLink = dbContext.ShortLinks
            .AsNoTracking()
            .FirstOrDefault(x => x.Token == token) ??
            throw new ArgumentException("The link not found.");

        CheckLinkExpiration(shortLink);
        AddClickEvent(token);
        return shortLink.MainLink;
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

    private void CheckLinkExpiration(ShortLink link)
    {
        if (link.DeadLine.HasValue && link.DeadLine < DateTimeOffset.Now)
            throw new Exception("The link has been expired.");
    }
    private void AddClickEvent(string token)
    {
        var click = new LinkClickInfo(token);
        dbContext.LinkClickInfos.Add(click);
        dbContext.SaveChanges();
    }

}
