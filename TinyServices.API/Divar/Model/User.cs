using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Divar.Model;

public class User : Entity
{
    protected User()
    {

    }
    public User(string name, Email email, PhoneNumber phoneNumber)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Advertisements = new List<Advertisement>();
    }

    public string Name { get; set; }
    public List<Advertisement> Advertisements { get; set; }
    public Email Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }

    public override string ToString()
    {
        return $"{Name} {PhoneNumber} {Email}";
    }
}
