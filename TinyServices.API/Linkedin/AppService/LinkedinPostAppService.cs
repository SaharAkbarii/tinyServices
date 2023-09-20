using Microsoft.EntityFrameworkCore;
using TinyServices.API.Linkedin.Model;
using TinyServices.API.Repository;

namespace TinyServices.API.Linkedin.AppService;
public class LinkedinPostAppService
{
    private readonly TinyServicesDbContext dbContext;

    public LinkedinPostAppService(TinyServicesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public LinkedinPost Create(Guid userId, string postDescription, List<string>? imageUrls)
    {
        var user = dbContext.LinkedinUsers.FirstOrDefault(x => x.Id == userId) ??
            throw new Exception($"user with id {userId} not found");

        var post = new LinkedinPost(user, postDescription);
        if (imageUrls != null)
            post.ImageUrls = imageUrls;

        dbContext.linkedinPosts.Add(post);
        dbContext.SaveChanges();
        return post;
    }

    public Like Like(Guid userId, Guid postId)
    {
        var user = dbContext.LinkedinUsers.FirstOrDefault(x => x.Id == userId) ??
          throw new Exception($"user with id {userId} not found");

        var post = dbContext.linkedinPosts
            .Include(x => x.Likes)
            .FirstOrDefault(x => x.Id == postId) ??
            throw new Exception($"post with id {postId} not found");
        var like = new Like(post, user);

        dbContext.Likes.Add(like);
        dbContext.SaveChanges();

        return like;
    }

    public Comment Comment(Guid userId, Guid postId, string commentBody)
    {
        var user = dbContext.LinkedinUsers.FirstOrDefault(x => x.Id == userId) ??
        throw new Exception($"user with id {userId} not found");

        var post = dbContext.linkedinPosts
            .Include(x => x.Comments)
            .FirstOrDefault(x => x.Id == postId) ??
            throw new Exception($"post with id {postId} not found");
        var comment = new Comment(post, user, commentBody);

        dbContext.Comments.Add(comment);
        dbContext.SaveChanges();
        return comment;
    }

    public LinkedinPost RemoveLike(Guid userId, Guid postId)
    {
        var post = dbContext.linkedinPosts
            .Include(x => x.Likes)
            .ThenInclude(x => x.LinkedinUser)
            .FirstOrDefault(x => x.Id == postId) ??
            throw new Exception($"post with id {postId} not found");

        var like = post.Likes.FirstOrDefault(x => x.LinkedinUser.Id == userId) ??
            throw new Exception($"user with id {userId} not found");

        post.Likes.Remove(like);
        dbContext.SaveChanges();
        return post;
    }

    public LinkedinPost RemoveComment(Guid cmId)
    {
        var cm = dbContext.Comments.FirstOrDefault(x => x.Id == cmId) ??
            throw new Exception($"comment with id {cmId} not found.");
        var post = cm.LinkedinPost;

        dbContext.Comments.Remove(cm);
        dbContext.SaveChanges();
        return post;
    }

}
