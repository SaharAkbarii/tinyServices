using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TinyServices.API.LinkService.AppServices;
using TinyServices.API.LinkService.Dto;

namespace TinyServices.API.LinkService.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : Controller
{
    private readonly CompanyService service;
    private readonly IMapper mapper;

    public CompanyController (CompanyService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }

    [HttpPost]
    public CompanyDto Create([FromBody] CreateCompanyInput input)
    {
        var company = service.Create(input.Name);
        var dto = mapper.Map<CompanyDto>(company);
        return dto;
    }

    [HttpGet]
    [Route("{id:guid}/ShortLinks")]
    public List<ShortLinkDto> GetShortLinks(Guid id)
    {
        var shortLinks = service.Get(id);
        var dto = mapper.Map<List<ShortLinkDto>>(shortLinks);
        return dto;
    }
}
