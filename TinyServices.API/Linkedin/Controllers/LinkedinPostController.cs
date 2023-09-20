using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TinyServices.API.Linkedin.AppService;
using TinyServices.API.Linkedin.Dto;
using TinyServices.API.Linkedin.Model;

namespace TinyServices.API.Linkedin.Controllers;


[ApiController]
[Route("[controller]")]
public class LinkedinPostController : Controller
{
    private readonly LinkedinPostAppService service;
    private readonly IMapper mapper;

    public LinkedinPostController(LinkedinPostAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }
    [HttpPost]
    public LinkedinPostDto Create([FromBody] CreateLinkedinPostInput input)
    {
        var post = service.Create(input.UserId, input.Description, input.ImageUrl);

        var dto = mapper.Map<LinkedinPostDto>(post);
        return dto;
    }
    [HttpPut]
    [Route("{id:guid}/like/{userId:guid}")]
    public LikeDto Like(Guid id, Guid userId)
    {
        var like = service.Like(userId, id);
        var dto = mapper.Map<LikeDto>(like);
        return dto;
    }

    [HttpPost]
    [Route("{id:guid}/comment/{userId:guid}")]
    public CommentDto Comment(Guid userId, Guid id,[FromBody] CreateCommentInput input)
    {
        var comment = service.Comment(userId, id, input.Body);
        var dto = mapper.Map<CommentDto>(comment);
        return dto;
    }

    [HttpDelete]
    [Route("{id:guid}/like/{userId:guid}")]
    public LinkedinPostDto RemoveLike(Guid id, Guid userId)
    {
        var post = service.RemoveLike(userId, id);
        var dto = mapper.Map<LinkedinPostDto>(post);
        return dto;
    }

    [HttpDelete]
    [Route("comment/{id:guid}")]
    public LinkedinPostDto RemoveComment(Guid id)
    {
        var post = service.RemoveComment(id);
        var dto = mapper.Map<LinkedinPostDto>(post);
        return dto;
    }

}

