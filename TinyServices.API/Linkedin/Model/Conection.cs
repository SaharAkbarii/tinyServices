using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Linkedin.Model;

public class Connection : Entity
{
    protected Connection()
    {
        
    }
    public Connection(LinkedinUser user, LinkedinUser connectionUser)
    {
        User = user;
        ConnectionUser = connectionUser;
    }
    public LinkedinUser User { get; set; }
    public LinkedinUser ConnectionUser { get; set; }
}
