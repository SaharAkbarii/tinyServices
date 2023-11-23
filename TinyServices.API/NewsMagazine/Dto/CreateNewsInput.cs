using TinyServices.API.NewsMagazine.Model;

namespace TinyServices.API.NewsMagazine.Dto;
public class CreateNewsInput
{
    public string Title { get; set; }
    public string Body { get; set; }
    public List<Guid> CategoryId {get; set;}
}
public class UpdateNewsInput
{
    public string Title { get; set; }
    public string Body { get; set; }
    public StatusDto State {get; set; }
}
