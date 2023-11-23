namespace TinyServices.API.NewsMagazine.Model;

public class NewsCommentInformation
{
    public Guid Id { get; set; }
    public NewsUserInformation NewsUser { get; set; }
    public string Body { get; set; }

}


