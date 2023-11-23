using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TinyServices.API.NewsMagazine.AppService;
using TinyServices.API.NewsMagazine.Dto;
using TinyServices.API.NewsMagazine.Model;

namespace TinyServices.API.NewsMagazine.Controllers;
[ApiController]
[Route("[controller]")]
public class NewsController : Controller
{

    private readonly NewsAppService service;
    private readonly IMapper mapper;

    public NewsController(NewsAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }
    [HttpPost]
    public NewsDto Create([FromBody] CreateNewsInput input)
    {
        var news = service.Create(input.Title, input.Body, input.CategoryId);

        var dto = mapper.Map<NewsDto>(news);
        return dto;
    }
    [HttpPut]
    [Route("{id:guid}")]
    public NewsDto Update(Guid id, [FromBody] UpdateNewsInput input)
    {
        var status = mapper.Map<Status>(input.State);
        var news = service.Update(id, input.Title, input.Body, status);
        var dto = mapper.Map<NewsDto>(news);
        return dto;
    }
    [HttpPut]
    [Route("{id:guid}/like/{userId:guid}")]
    public NewsDto Like(Guid id, Guid userId)
    {
        var news = service.Like(id, userId);
        var dto = mapper.Map<NewsDto>(news);
        return dto;
    }
    [HttpPut]
    [Route("{id:guid}/dislike/{userId:guid}")]
    public NewsDto DisLike(Guid id, Guid userId)
    {
        var news = service.DisLike(id, userId);
        var dto = mapper.Map<NewsDto>(news);
        return dto;
    }

    [HttpPost]
    [Route("{id:guid}/comment/{userId:guid}")]
    public NewsDto Comment(Guid id, Guid userId, [FromBody] CreateNewsCommentInput input)
    {
        var comment = service.Comment(id, userId, input.Body);
        var dto = mapper.Map<NewsDto>(comment);
        return dto;
    }

    [HttpGet]
    [Route("{id:guid}")]
    public NewsDto GetNews(Guid id)
    {
        var news = service.GetNews(id);
        var dto = mapper.Map<NewsDto>(news);
        return dto;
    }
}
