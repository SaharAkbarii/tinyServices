using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using TinyServices.API.Divar.Model;
using TinyServices.API.Repository;

namespace TinyServices.API.Divar.AppService;
public class UserAppService
{
    private readonly TinyServicesDbContext dbContext;

    public UserAppService(TinyServicesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public User Create(string name, string emailValue, string phoneNumberValue)
    {
        var email = new Email(emailValue);
        var phoneNumber = new PhoneNumber(phoneNumberValue);
        var user = new User(name, email, phoneNumber);
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
        return user;
    }

    public User Search(Guid id)
    {
        var user = dbContext.Users
        .Include(x=> x.Advertisements)
        .ThenInclude(x=> x.Category)
        .Include(x=> x.Advertisements)
        .ThenInclude(x=> x.PropertyValues)
        .Include(x=> x.Advertisements)
        .ThenInclude(x=> x.Category.Properties)
        .FirstOrDefault(x => x.Id == id)??
            throw new Exception("user not found!");
        
        return user;
    }
}
