using TinyServices.API.LinkService.Model;

namespace TinyServices.API.NewsMagazine.Model;

public class NewsViewInfo: Entity
{
    public NewsViewInfo(Guid newsId)
    {
        NewsId = newsId;
    }

    public Guid NewsId { get; set; }
}
