using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Linkedin.Model;

public class Like : Entity
{
    protected Like()
    {
        
    }
    public Like(LinkedinPost linkedinPost, LinkedinUser linkedinUser)
    {
        LinkedinPost = linkedinPost;
        LinkedinUser = linkedinUser;
    }

    public LinkedinPost LinkedinPost { get; set; }
    public LinkedinUser LinkedinUser { get; set; }
}
