using TinyServices.API.LinkService.Model;

namespace TinyServices.API.NewsMagazine.Model;

public class NewsDisLike<TEntity> : Entity
{
    protected NewsDisLike()
    {

    }
    public NewsDisLike(TEntity likedEntity, NewsUser newsUser)
    {
        LikedEntity = likedEntity;
        NewsUser = newsUser;
    }

    public TEntity LikedEntity { get; set; }
    public NewsUser NewsUser { get; set; }
}

