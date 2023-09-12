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

    [HttpPut]
    [Route("{id:guid}/comment/{userId:guid}")]
    public CommentDto Comment(Guid userId, Guid id,[FromBody] CreateCommentInput input)
    {
        var comment = service.Comment(userId, id, input.Body);
        var dto = mapper.Map<CommentDto>(comment);
        return dto;
    }

    [HttpDelete]
    [Route("{postId:guid}/like/{userId:guid}")]
    public LinkedinPostDto RemoveLike(Guid postId, Guid userId)
    {
        var post = service.RemoveLike(userId, postId);
        var dto = mapper.Map<LinkedinPostDto>(post);
        return dto;
    }

    [HttpDelete]
    [Route("{cmId:guid}/cm")]
    public LinkedinPostDto RemoveCm(Guid cmId)
    {
        var post = service.RemoveCm(cmId);
        var dto = mapper.Map<LinkedinPostDto>(post);
        return dto;
    }

}

