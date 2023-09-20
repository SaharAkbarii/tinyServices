namespace TinyServices.API.LinkService.Model;
public class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}