using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Linkedin.Model;

public class Comment : Entity
{
    protected Comment()
    {

    }
    public Comment(LinkedinPost linkedinPost, LinkedinUser linkedinUser, string body)
    {
        LinkedinPost = linkedinPost;
        LinkedinUser = linkedinUser;
        Body = body;
    }

    public LinkedinPost LinkedinPost { get; set; }
    public LinkedinUser LinkedinUser {get; set;}
    public string Body { get; set; }
}
