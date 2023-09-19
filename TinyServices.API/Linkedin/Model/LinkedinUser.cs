using TinyServices.API.Divar.Model;
using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Linkedin.Model;
public class LinkedinUser : Entity
{
    private List<Connection>? _conections;
    private List<ConnectionRequest>? _connectionRequests;

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
    public List<Connection> Conections
    {
        get
        {
            if (_conections == null)

                _conections = new List<Connection>();

            return _conections;
        }
        set => _conections = value;
    }
    public List<ConnectionRequest> ConnectionRequests
    {
        get
        {
            if (_connectionRequests == null)
                _connectionRequests = new List<ConnectionRequest>();

            return _connectionRequests;
        }
        set => _connectionRequests = value;
    }
    private static string CreateMD5(string input)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }



}
