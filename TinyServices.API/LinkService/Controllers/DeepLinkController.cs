using Microsoft.AspNetCore.Mvc;
using TinyServices.API.LinkService.AppServices;
using TinyServices.API.LinkService.Dto;


namespace TinyServices.API.LinkService.Controllers;

[ApiController]
[Route("[controller]")]

public class DeepLinkController : ControllerBase
{
    private readonly DeepLinkService service;
    public DeepLinkController(DeepLinkService service)
    {
        this.service = service;
    }

    [HttpPost]
    public string Generate ([FromBody] CreateDeepLinkInput input)
    {
        var deepLink = service.Generate(input.DefaultRoute, input.IosLink, input.AndroidLink, input.DesktopLink, input.deadLine);
        return deepLink;
    }

    [HttpGet]
    [Route("{url}/{device}")]
    public string Resolve (string url, string device)
    {
        var link = service.Resolve(url, device);
        return link;
    }
}