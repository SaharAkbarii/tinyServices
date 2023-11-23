using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TinyServices.API.Divar.Dto;
using TinyServices.API.NewsMagazine.AppService;
using TinyServices.API.NewsMagazine.Dto;

namespace TinyServices.API.NewsMagazine.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsUserController : Controller
{
    private readonly NewsUserAppService service;
    private readonly IMapper mapper;

    public NewsUserController(NewsUserAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }
    [HttpPost]
    public NewsUserDto Create([FromBody] CreateNewsUserInput input)
    {
        var user = service.Create(input.Name, input.Email);

        var dto = mapper.Map<NewsUserDto>(user);
        return dto;
    }

    [HttpGet]
    [Route("Feed/{userId:guid}")]
    public List<NewsInformationDto> Feed(int count, int offset, Guid userId)
    {
        var news = service.Feed(count, offset, userId);
        var dto = mapper.Map<List<NewsInformationDto>>(news);
        return dto;
    }

    [HttpPut]
    [Route("{id:guid}/set/category")]
    public NewsUserDto SetFavoriteCategory(Guid id,[FromBody]CreateFavoriteCategory input)
    {
        var user = service.SetFavoriteCategory(id, input.CategoryIds);
        var dto = mapper.Map<NewsUserDto>(user);
        return dto;
    }
}   