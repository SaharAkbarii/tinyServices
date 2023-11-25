using Microsoft.EntityFrameworkCore;
using TinyServices.API.Divar.Model;
using TinyServices.API.NewsMagazine.Model;
using TinyServices.API.Repository;

namespace TinyServices.API.NewsMagazine.AppService;
public class NewsUserAppService
{
    private readonly TinyServicesDbContext dbContext;

    public NewsUserAppService(TinyServicesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public NewsUser Create(string name, string emailvalue)
    {
        var email = new Email(emailvalue);
        var user = new NewsUser(email, name);
        dbContext.NewsUsers.Add(user);
        dbContext.SaveChanges();
        return user;
    }
    public List<NewsInformation> Feed(int count, int offset, Guid userId)
    {
        var query = dbContext.News
            .Include(x => x.Likes)
            .Include(x => x.Comments)
            .Include(x => x.DisLikes)
            .Include(x => x.NewsCategories)
                .ThenInclude(c => c.NewsCategory)
            .Where(x => x.Status == Status.Publish);

        var user = dbContext.NewsUsers
            .Include(x => x.FavoriteCategories)
                .ThenInclude(c => c.Category)
            .FindModel(userId);

        if (user.FavoriteCategories != null && user.FavoriteCategories.Any())
        {
            var categoryIds = user.FavoriteCategories.Select(x => x.Category.Id);
            query = query.Where(x => x.NewsCategories.Any(y => categoryIds.Any(c => c == y.NewsCategory.Id)));
        }

        var result = query.OrderByDescending(x => x.PublishAt)
        .Skip(offset)
        .Take(count)
        .Select(x => new NewsInformation
        {

            Id = x.Id,
            Body = x.Body.Substring(0, x.Body.Length < 50 ? x.Body.Length : 50),
            DisLikes = x.DisLikes.Count,
            Likes = x.Likes.Count,
            NewsNumber = x.NewsNumber,
            PublishAt = x.PublishAt,
            Title = x.Title,
            ViewCount = dbContext.NewsViewInfos.Count(n => n.NewsId == x.Id),
            Comments = x.Comments.OrderByDescending(x => x.CreatedAt)
                .Take(10)
                .Select(c => new NewsCommentInformation
                {
                    Id = c.Id,
                    Body = c.Body,
                    NewsUser = new NewsUserInformation
                    {
                        Id = c.NewsUser.Id,
                        Name = c.NewsUser.Name
                    }

                })
                .ToList()
        })
        .ToList();


        return result;
    }
    public NewsUser SetFavoriteCategory(Guid userId, List<Guid> categoryIds)
    {
        var user = dbContext.NewsUsers.FindModel(userId);

        user.FavoriteCategories.Clear();
        for (int i = 0; i < categoryIds.Count; i++)
        {
            var category = dbContext.NewsCategories.FindModel(categoryIds[i]);
            var favoriteCategory = new FavoriteCategory(user, category);
            user.FavoriteCategories.Add(favoriteCategory);
        }
        dbContext.SaveChanges();
        return user;
    }
}
