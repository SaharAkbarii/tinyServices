using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using TinyServices.API.Divar.Model;
using TinyServices.API.Linkedin.Model;
using TinyServices.API.Repository;

namespace TinyServices.API.Linkedin.AppService;
public class LinkedinUserAppService
{
    private readonly TinyServicesDbContext dbContext;

    public LinkedinUserAppService(TinyServicesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public LinkedinUser Create(string userName, string password, string emailValue)
    {
        var email = new Email(emailValue);
        var user = new LinkedinUser(userName, password, email);
        dbContext.LinkedinUsers.Add(user);
        dbContext.SaveChanges();
        return user;
    }

    public ConnectionRequest SendConnectionRequest(Guid senderId, Guid receiverId)
    {
        ThrowIfRequestIsAlreadyExisted(senderId, receiverId);

        var sender = dbContext.LinkedinUsers.FirstOrDefault(x => x.Id == senderId) ??
            throw new Exception($"user with id {senderId} not found");

        var receiver = dbContext.LinkedinUsers.FirstOrDefault(x => x.Id == receiverId) ??
            throw new Exception($"user with id {receiverId} not found");

        var connectionRequest = new ConnectionRequest(sender, receiver);

        dbContext.ConnectionRequests.Add(connectionRequest);
        dbContext.SaveChanges();
        return connectionRequest;
    }
    public Connection AcceptConnectRequest(Guid connectionRequestId)
    {
        var connectionRequest = dbContext.ConnectionRequests
            .Include(x => x.Sender)
            .Include(x => x.Receiver)
            .FirstOrDefault(x => x.Id == connectionRequestId) ??
                throw new Exception($"connection with id {connectionRequestId} not found");
        connectionRequest.Accept();
        var conection1 = new Connection(connectionRequest.Receiver, connectionRequest.Sender);
        var conection2 = new Connection(connectionRequest.Sender, connectionRequest.Receiver);

        // dbContext.ConnectionRequests.Remove(connectionRequest);
        dbContext.Connections.AddRange(conection1, conection2);
        dbContext.SaveChanges();
        return conection1;
    }
    public void RejectConnectRequest(Guid connectionRequestId)
    {
        var connectionRequest = dbContext.ConnectionRequests.FirstOrDefault(x => x.Id == connectionRequestId) ??
                throw new Exception($"connection with id {connectionRequestId} not found");

        connectionRequest.Reject();
        dbContext.SaveChanges();
    }
    public List<PostInformation> Feed(Guid id, int offset, int count)
    {
        var posts = dbContext.linkedinPosts
            .Include(x => x.User)
            .Where(x => x.User.Conections.Any(y => y.ConnectionUser.Id == id))
            .OrderByDescending(x => x.CreatedAt)
            .Skip(offset)
            .Take(count)
            .Select(x => new PostInformation
            {
                Id = x.Id,
                Description = x.Description,
                PostedAt = x.CreatedAt,
                ImageUrls = x.ImageUrls,
                PostedBy = new LinkedinUserInformation(x.User.Id, x.User.UserName),
                Likes = x.Likes.Count(),
                Commenters = x.Comments.OrderByDescending(x=> x.CreatedAt)
                    .Take(3)
                    .Select(c=> new LinkedinUserInformation(c.LinkedinUser.Id, c.LinkedinUser.UserName))
                    .ToList()
            })
            .ToList();

        return posts;
    }

    private void ThrowIfRequestIsAlreadyExisted(Guid senderId, Guid receiverId)
    {
        if (dbContext.ConnectionRequests.Any(x => x.Sender.Id == senderId && x.Receiver.Id == receiverId && x.Status != ConnectionRequestStatus.Accepted))
            throw new Exception($"connection with user id {receiverId} is forbidden");

        if (dbContext.Connections.Any(x => x.User.Id == senderId && x.ConnectionUser.Id == receiverId))
            throw new Exception($"connection has already existed");
    }
}
