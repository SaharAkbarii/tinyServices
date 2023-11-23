using AutoMapper.Internal.Mappers;
using Microsoft.EntityFrameworkCore;
using TinyServices.API.NewsMagazine.Model;
using TinyServices.API.Repository;

namespace TinyServices.API.NewsMagazine.AppService;
public class NewsAppService
{
    private readonly TinyServicesDbContext dbContext;

    public NewsAppService(TinyServicesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public News Create(string title, string body, List<Guid> categoryId)
    {
        var news = new News(title, body);
        news.NewsNumber = GenerateNewsNumber();
        for (var i = 0; i < categoryId.Count; i++)
        {
            var category = dbContext.NewsCategories.FirstOrDefault(x => x.Id == categoryId[i]) ??
                throw new Exception($"category with id: {categoryId[i]} not found.");
            var categoryContainer = new NewsCategoryContainer(category, news);
            news.NewsCategories.Add(categoryContainer);
        }
        dbContext.News.Add(news);
        dbContext.SaveChanges();
        return news;
    }

    public News Update(Guid newsId, string title, string body, Status status)
    {
        var news = dbContext.News.FirstOrDefault(x => x.Id == newsId) ??
            throw new Exception($"news with id {newsId} not found");
        news.Title = title;
        news.Body = body;
        news.ChangeStatus(status);
        dbContext.SaveChanges();
        return news;
    }

    public News Like(Guid newsId, Guid userId)
    {
        var news = dbContext.News
            .Include(x => x.Likes)
            .ThenInclude(x => x.NewsUser)
            .Include(x => x.Comments)
            .Include(x => x.DisLikes)
            .FirstOrDefault(x => x.Id == newsId) ??
            throw new Exception($"news with id {newsId} not found");

        var user = dbContext.NewsUsers.FirstOrDefault(x => x.Id == userId) ??
           throw new Exception($"user with id {userId} not found");

        if (news.Likes.Any(x => x.NewsUser.Id == userId))
            throw new Exception("the user has already liked this post!");
        var like = new NewsLike(news, user);

        news.Likes.Add(like);
        dbContext.NewsLikes.Add(like);
        dbContext.SaveChanges();

        return news;

    }

    public News DisLike(Guid newsId, Guid userId)
    {
        var news = dbContext.News
            .Include(x => x.Likes)
            .Include(x => x.Comments)
            .Include(x => x.DisLikes)
            .ThenInclude(x => x.NewsUser)
            .FirstOrDefault(x => x.Id == newsId) ??
            throw new Exception($"news with id {newsId} not found");

        var user = dbContext.NewsUsers.FirstOrDefault(x => x.Id == userId) ??
           throw new Exception($"user with id {userId} not found");
        var dislike = new NewsDisLike(news, user);

        news.DisLikes.Add(dislike);
        dbContext.NewsDisLikes.Add(dislike);
        dbContext.SaveChanges();

        return news;
    }

    public News Comment(Guid newsId, Guid userId, string body)
    {
        var news = dbContext.News
            .Include(x => x.Likes)
            .Include(x => x.Comments)
            .ThenInclude(x => x.NewsUser)
            .Include(x => x.DisLikes)
            .FirstOrDefault(x => x.Id == newsId) ??
            throw new Exception($"news with id {newsId} not found");

        var user = dbContext.NewsUsers.FirstOrDefault(x => x.Id == userId) ??
           throw new Exception($"user with id {userId} not found");
        var comment = new NewsComment(news, user, body);

        news.Comments.Add(comment);
        dbContext.NewsComments.Add(comment);
        dbContext.SaveChanges();

        return news;
    }
    public News GetNews(Guid id)
    {
        var news = dbContext.News
            .Include(x => x.Likes)
            .Include(x => x.Comments)
            .Include(x => x.DisLikes)
            .Include(x => x.NewsCategories)
                .ThenInclude(c => c.NewsCategory)
            .FirstOrDefault(x => x.Id == id);
            
        AddViewEvent(id);
        return news;
    }
    private void AddViewEvent(Guid id)
    {
        var view = new NewsViewInfo(id);
        dbContext.NewsViewInfos.Add(view);
        dbContext.SaveChanges();
    }

    private Int64 GenerateNewsNumber()
    {
        Random rnd = new Random();
        for (int i = 0; i < 5; i++)
        {
            var number = rnd.NextInt64(10000000, 9999999999);
            if (!dbContext.News.Any(x => x.NewsNumber == number))
            {
                return number;
            }
        }
        throw new Exception("number can not be generated.");
    }


}
