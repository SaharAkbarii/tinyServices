using TinyServices.API.Divar.Model;
using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Linkedin.Model;
public class LinkedinUser : Entity
{
    protected LinkedinUser()
    {

    }
    public LinkedinUser(string userName, string password, Email email)
    {
        UserName = userName;
        PasswordHash = CreateMD5(password);
        Email = email;
    }

    public string UserName { get; set; }
    public string PasswordHash { get; private set; }
    public Email Email { get; set; }
    public List<Connection>? Conections { get; set; }

    public static string CreateMD5(string input)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }

    public void AddingConnections(Connection connection)
    {
        if(connection.IsConfirmed)
            Conections.Add(connection);
    }

}
