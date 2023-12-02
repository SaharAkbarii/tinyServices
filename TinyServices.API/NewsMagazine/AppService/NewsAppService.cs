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

    public async Task<News> Create(string title, string body, List<Guid> categoryId)
    {
        var news = new News(title, body);
        news.NewsNumber = GenerateNewsNumber();
        var categories = await dbContext.NewsCategories
            .Where(x => categoryId.Any(i => i == x.Id))
            .ToListAsync();

        foreach (var category in categories)
        {
            var categoryContainer = new NewsCategoryContainer(category, news);
            news.NewsCategories.Add(categoryContainer);
        }
        await dbContext.News.AddAsync(news);
        await dbContext.SaveChangesAsync();
        return news;
    }

    public async Task<News> Update(Guid newsId, string title, string body, Status status)
    {
        var news = await dbContext.News.FindModelAsync(newsId);
        news.Title = title;
        news.Body = body;
        news.ChangeStatus(status);
        await dbContext.SaveChangesAsync();
        return news;
    }

    public async Task<News> Like(Guid newsId, Guid userId)
    {
        var news = await dbContext.News
            .Include(x => x.Likes)
            .ThenInclude(x => x.NewsUser)
            .Include(x => x.Comments)
            .Include(x => x.DisLikes)
            .FindModelAsync(newsId);

        var user = await dbContext.NewsUsers.FindModelAsync(userId);

        if (news.Likes.Any(x => x.NewsUser.Id == userId))
            throw new Exception("the user has already liked this post!");
        if (news.Status != Status.Publish)
            throw new Exception("You can't like this news.");
        if (DateTimeOffset.UtcNow.AddMonths(-1) > news.PublishAt)
            throw new Exception("the news can't be liked.");

        var like = new NewsLike<News>(news, user);

        news.Likes.Add(like);
        await dbContext.NewsLikes.AddAsync(like);
        await dbContext.SaveChangesAsync();

        return news;

    }
    public async Task<NewsComment> CommentLike(Guid commentId, Guid userId)
    {
        var comment = await dbContext.NewsComments
            .Include(x => x.Likes)
            .ThenInclude(x => x.NewsUser)
            .FindModelAsync(commentId);

        var user = await dbContext.NewsUsers.FindModelAsync(userId);

        if (comment.Likes.Any(x => x.NewsUser.Id == userId))
            throw new Exception("the user has already liked this post!");
        var like = new NewsLike<NewsComment>(comment, user);

        comment.Likes.Add(like);
        await dbContext.NewsCommentLikes.AddAsync(like);
        await dbContext.SaveChangesAsync();

        return comment;

    }

    public async Task<News> DisLike(Guid newsId, Guid userId)
    {
        var news = await dbContext.News
            .Include(x => x.Likes)
            .Include(x => x.Comments)
            .Include(x => x.DisLikes)
            .ThenInclude(x => x.NewsUser)
            .FindModelAsync(newsId);

        var user = await dbContext.NewsUsers.FindModelAsync(userId);
        var dislike = new NewsDisLike<News>(news, user);

        news.DisLikes.Add(dislike);
        await dbContext.NewsDisLikes.AddAsync(dislike);
        await dbContext.SaveChangesAsync();

        return news;
    }

    public async Task<News> Comment(Guid newsId, Guid userId, string body)
    {
        var news = await dbContext.News
            .Include(x => x.Likes)
            .Include(x => x.Comments)
            .ThenInclude(x => x.NewsUser)
            .Include(x => x.DisLikes)
            .FindModelAsync(newsId);

        var user = await dbContext.NewsUsers.FindModelAsync(userId);
        var comment = new NewsComment(news, user, body);

        news.Comments.Add(comment);
        await dbContext.NewsComments.AddAsync(comment);
        await dbContext.SaveChangesAsync();

        return news;
    }
    public async Task<News> GetNews(Guid id)
    {
        var news = await dbContext.News
            .Include(x => x.Likes)
            .Include(x => x.Comments)
            .Include(x => x.DisLikes)
            .Include(x => x.NewsCategories)
                .ThenInclude(c => c.NewsCategory)
            .FindModelAsync(id);

        await AddViewEvent(id);
        return news;
    }
    private async Task AddViewEvent(Guid id)
    {
        var view = new NewsViewInfo(id);
        dbContext.NewsViewInfos.Add(view);
        await dbContext.SaveChangesAsync();
    }

    private long GenerateNewsNumber()
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
