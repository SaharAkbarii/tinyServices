namespace TinyServices.API.Linkedin.Model;

public class LinkedinUserInformation 
{
    public LinkedinUserInformation(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}

