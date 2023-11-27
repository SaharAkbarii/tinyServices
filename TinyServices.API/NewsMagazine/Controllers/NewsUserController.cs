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
    public async Task<NewsUserDto> Create([FromBody] CreateNewsUserInput input)
    {
        var user =await service.Create(input.Name, input.Email);

        var dto = mapper.Map<NewsUserDto>(user);
        return dto;
    }

    [HttpGet]
    [Route("Feed/{userId:guid}")]
    public async Task<List<NewsInformationDto>> Feed(int count, int offset, Guid userId)
    {
        var news =await service.Feed(count, offset, userId);
        var dto = mapper.Map<List<NewsInformationDto>>(news);
        return dto;
    }

    [HttpPut]
    [Route("{id:guid}/set/category")]
    public async Task<NewsUserDto> SetFavoriteCategory(Guid id,[FromBody]CreateFavoriteCategory input)
    {
        var user =await service.SetFavoriteCategory(id, input.CategoryIds);
        var dto = mapper.Map<NewsUserDto>(user);
        return dto;
    }
}   