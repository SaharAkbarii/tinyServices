namespace TinyServices.API.Linkedin.Dto;

public class ConnectionRequestDto
{
    public Guid Id { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public ConnectionRequestStatusDto Status { get; set; }
}

public enum ConnectionRequestStatusDto
{
    Pending,
    Rejected,
    Accepted,
}
