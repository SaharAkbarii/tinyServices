using Microsoft.AspNetCore.Mvc;
using TinyServices.API.LinkService.AppServices;
using TinyServices.API.LinkService.Dto;


namespace TinyServices.API.LinkService.Controllers;

[ApiController]
[Route("[controller]")]
public class ShortLinkController : ControllerBase
{
    private readonly ShortLinkService service;
    public ShortLinkController(ShortLinkService service)
    {
        this.service = service;
    }

    [HttpPost]
    public string Generate([FromBody] CreateShortLinkInput input)
    {
        var shortLink = service.Generate(input.MainLink, input.DeadLine, input.CompanyId);
        
        return shortLink;
    }

    [HttpGet]
    [Route("{shortenLink}")]

    public string Resolve(string shortenLink)
    {
        var shortLink = service.Resolve(shortenLink);
        return shortLink;
    }

}

