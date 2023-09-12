namespace TinyServices.API.LinkService.Dto;
public class DeepLinkDto
{
    public string DefaultRoute { get; set; }
    public string IosLink { get; set; }
    public string AndroidLink { get; set; }
    public string DesktopLink { get; set; }
    public string ShortenLink { get; set; }
    public Guid Id { get; set; }
}