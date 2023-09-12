using System.Web;
using Microsoft.EntityFrameworkCore;
using TinyServices.API.LinkService.Model;
using TinyServices.API.Repository;

namespace TinyServices.API.LinkService.AppServices;
public class OneTimeLinkService
{
    private readonly TinyServicesDbContext dbContext;
    private readonly IConfiguration configuration;
    public OneTimeLinkService(TinyServicesDbContext dbContext, IConfiguration configuration)
    {
        this.dbContext = dbContext;
        this.configuration = configuration;
    }

    public string Generate(string text)
    {
        var token = GenerateToken();
        var oneTimeLink = new OneTimeLink(text, token);

        var shortenLink = configuration.GetValue<string>("OneTimeLinkUrl") + token;

        dbContext.oneTimeLinks.Add(oneTimeLink);
        dbContext.SaveChanges();

        return shortenLink;
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

    public string Resolve(string shortenLink)
    {
        shortenLink = HttpUtility.UrlDecode(shortenLink);
        var uri = new Uri(shortenLink);
        var token = new string(uri.AbsolutePath.Skip(1).ToArray());

        var oneTimeLink = dbContext.oneTimeLinks
            .FirstOrDefault(x => x.Token == token && !x.IsVisited) ??
            throw new ArgumentException("The link not found.");

        oneTimeLink.Visit();
        dbContext.SaveChanges();

        return oneTimeLink.Text;
    }


}
