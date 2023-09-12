using Microsoft.AspNetCore.Mvc;
using TinyServices.API.LinkService.AppServices;
using TinyServices.API.LinkService.Dto;


namespace TinyServices.API.LinkService.Controllers;

[ApiController]
[Route("[controller]")]

public class OneTimeLinkController : ControllerBase
{
    private readonly OneTimeLinkService service;

    public OneTimeLinkController(OneTimeLinkService service)
    {
        this.service = service;
    }

    [HttpPost]
    public string Generate([FromBody] CreateOneTimeLinkInput input)
    {
        var shortenLink = service.Generate(input.Text);
        return shortenLink;
    }

    [HttpGet]
    [Route("{shortenLink}")]
    public string Resolve(string shortenLink)
    {
        var link = service.Resolve(shortenLink);
        return link;
    }
}
