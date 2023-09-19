using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Linkedin.Model;

public class ConnectionRequest : Entity
{
    protected ConnectionRequest()
    {
        
    }
    public ConnectionRequest(LinkedinUser sender, LinkedinUser receiver)
    {
        Sender = sender;
        Receiver = receiver;
        Status = ConnectionRequestStatus.Pending;
    }

    public LinkedinUser Sender { get; set; }
    public LinkedinUser Receiver { get; set; }
    public ConnectionRequestStatus Status { get; private set; }

    public void Reject()
    {
        Status = ConnectionRequestStatus.Rejected;
    }

    public void Accept()
    {
        Status = ConnectionRequestStatus.Accepted;
    }

}

public enum ConnectionRequestStatus
{
    Pending,
    Rejected,
    Accepted,
}
