using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Linkedin.Model;

public class Connection : Entity
{
    protected Connection(LinkedinUser user)
    {
        User = user;
        IsConfirmed = false;
    }
    public LinkedinUser User { get; set; }
    public bool IsConfirmed { get; set; }
}