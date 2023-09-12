using Microsoft.AspNetCore.Mvc;
using TinyServices.API.LinkService.AppServices;

namespace TinyServices.API.LinkService.Controllers;

[ApiController]
[Route("[controller]")]

public class LinkInsightController : ControllerBase
{
    private readonly LinkInsightService service;
    public LinkInsightController(LinkInsightService service)
    {
        this.service = service;
    }
    // [HttpGet]
    // [Route("{token}")]
    // public int GetTotalLinkInsight(string token)
    // {
    //     var result = service.GetLinkInsight(token);
    //     return result;
    // }
}
