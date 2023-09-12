namespace TinyServices.API.LinkService.Dto;

public class CreateDeepLinkInput
{
    public string DefaultRoute { get; set; }
    public string IosLink { get; set; }
    public string AndroidLink { get; set; }
    public string DesktopLink { get; set; }
    public DateTimeOffset? deadLine {get; set;}
}
