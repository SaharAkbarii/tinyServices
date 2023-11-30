using TinyServices.API.LinkService.Model;

namespace TinyServices.API.NewsMagazine.Model;

public class NewsLike<TEntity> : Entity 
{
    protected NewsLike()
    {

    }
    public NewsLike(TEntity likedEntity, NewsUser newsUser)
    {
        LikedEntity = likedEntity;
        NewsUser = newsUser;
    }

    public TEntity LikedEntity { get; set; }
    public NewsUser NewsUser { get; set; }
}

