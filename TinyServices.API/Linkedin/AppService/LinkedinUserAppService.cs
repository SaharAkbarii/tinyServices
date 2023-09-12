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
}
