using TinyServices.API.LinkService.Model;

namespace TinyServices.API.NewsMagazine.Model;

public class NewsCategoryContainer : Entity
{
    protected NewsCategoryContainer()
    {
        
    }
    public NewsCategoryContainer(NewsCategory newsCategory, News news)
    {
        NewsCategory = newsCategory;
        News = news;
    }

    public NewsCategory NewsCategory { get; set; }
    public News News { get; set; }
}

