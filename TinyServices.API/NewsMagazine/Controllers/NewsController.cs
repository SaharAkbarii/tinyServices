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
    public async Task<NewsDto> Create([FromBody] CreateNewsInput input)
    {
        var news = await service.Create(input.Title, input.Body, input.CategoryId);

        var dto = mapper.Map<NewsDto>(news);
        return dto;
    }
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<NewsDto> Update(Guid id, [FromBody] UpdateNewsInput input)
    {
        var status = mapper.Map<Status>(input.State);
        var news = await service.Update(id, input.Title, input.Body, status);
        var dto = mapper.Map<NewsDto>(news);
        return dto;
    }
    [HttpPut]
    [Route("{id:guid}/like/{userId:guid}")]
    public async Task<NewsDto> Like(Guid id, Guid userId)
    {
        var news = await service.Like(id, userId);
        var dto = mapper.Map<NewsDto>(news);
        return dto;
    }
    [HttpPut]
    [Route("comment/{commentId:guid}/like/{userId:guid}")]
    public async Task<NewsCommentDto> CommentLike(Guid commentId, Guid userId)
    {
        var comment = await service.CommentLike(commentId, userId);
        var dto = mapper.Map<NewsCommentDto>(comment);
        return dto;
    }
    [HttpPut]
    [Route("{id:guid}/dislike/{userId:guid}")]
    public async Task<NewsDto> DisLike(Guid id, Guid userId)
    {
        var news = await service.DisLike(id, userId);
        var dto = mapper.Map<NewsDto>(news);
        return dto;
    }
    [HttpPut]
    [Route("comment/{commentId:guid}/dislike/{userId:guid}")]
    public async Task<NewsCommentDto> CommentDisLike(Guid commentId, Guid userId)
    {
        var comment = await service.CommentDisLike(commentId, userId);
        var dto = mapper.Map<NewsCommentDto>(comment);
        return dto;
    }

    [HttpPost]
    [Route("{id:guid}/comment/{userId:guid}")]
    public async Task<NewsDto> Comment(Guid id, Guid userId, [FromBody] CreateNewsCommentInput input)
    {
        var comment = await service.Comment(id, userId, input.Body);
        var dto = mapper.Map<NewsDto>(comment);
        return dto;
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<NewsDto> GetNews(Guid id)
    {
        var news = await service.GetNews(id);
        var dto = mapper.Map<NewsDto>(news);
        return dto;
    }
}
