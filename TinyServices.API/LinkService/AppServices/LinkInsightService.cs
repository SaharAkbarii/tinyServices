using TinyServices.API.LinkService.Model;
using TinyServices.API.Repository;

namespace TinyServices.API.LinkService.AppServices;
public class LinkInsightService
{
    private readonly TinyServicesDbContext dbContext;
    public LinkInsightService(TinyServicesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public LinkInsight GetLinkInsight(string token)
    {
        var query = dbContext.LinkClickInfos.Where(x => x.Token == token);
        var linkInsight = new LinkInsight();
        linkInsight.TotalClickCount = query.Count();
        return linkInsight;
    }
    
}
