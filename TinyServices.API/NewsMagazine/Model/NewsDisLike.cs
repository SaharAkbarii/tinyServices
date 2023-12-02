using TinyServices.API.LinkService.Model;

namespace TinyServices.API.NewsMagazine.Model;

public class NewsDisLike<TEntity> : Entity
{
    protected NewsDisLike()
    {

    }
    public NewsDisLike(TEntity likedEntity, NewsUser newsUser)
    {
        DisLikedEntity = likedEntity;
        NewsUser = newsUser;
    }

    public TEntity DisLikedEntity { get; set; }
    public NewsUser NewsUser { get; set; }
}

