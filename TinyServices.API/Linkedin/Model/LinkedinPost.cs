using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Linkedin.Model;
public class LinkedinPost : Entity
{
    private List<Like>? likes;
    private List<Comment>? comments;

    protected LinkedinPost()
    {

    }
    public LinkedinPost(LinkedinUser user, string postDescription)
    {
        User = user;
        Description = postDescription;
    }

    public LinkedinUser User { get; set; }
    public List<string>? ImageUrls { get; set; }
    public string Description { get; set; }
    public List<Like>? Likes
    {
        get
        {
            if (likes == null)
                likes = new List<Like>();
            return likes;
        }
        set => likes = value;
    }
    public List<Comment>? Comments
    {
        get
        {
            if (comments == null)
                comments = new List<Comment>();
            return comments;
        }
        set => comments = value;
    }

}