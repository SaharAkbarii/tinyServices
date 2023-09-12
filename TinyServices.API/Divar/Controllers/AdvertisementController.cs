using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TinyServices.API.Divar.AppService;
using TinyServices.API.Divar.Dto;
using TinyServices.API.Divar.Model;

namespace TinyServices.API.Divar.Controllers;

[ApiController]
[Route("[controller]")]
public class AdvertisementController : Controller
{
    private readonly AdvertisementAppService service;
    private readonly IMapper mapper;

    public AdvertisementController(AdvertisementAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }

    [HttpPost]
    public AdvertisementDto Create([FromBody] CreateAdvertisementInput input)
    {

        var dictionary = input.PropertyValues.ToDictionary(x => x.PropertyId, x => x.Value);
        var advertisement = service.Create(input.CategoryId,
            input.Title,
            input.City,
            input.Neighborhood,
            input.PhoneNumber,
            dictionary,
            input.UserId,
            input.Price,
            input.UrlImage);

        var dto = mapper.Map<AdvertisementDto>(advertisement);
        return dto;
    }

    [HttpGet]
    [Route("Feed")]
    public SearchResultDto<AdvertisementDto> Feed(string city, Guid? categoryId, string? keyWord, int count, int offset)
    {
        var advertisements = service.Feed(city, categoryId, keyWord, count, offset);
        var dto = mapper.Map<SearchResultDto<AdvertisementDto>>(advertisements);
        return dto;
    }

    [HttpPut]
    [Route("{id:guid}/approve")]
    public AdvertisementDto Approve(Guid id)
    {
        var advertisement = service.Approve(id);
        var dto = mapper.Map<AdvertisementDto>(advertisement);
        return dto;
    }
}