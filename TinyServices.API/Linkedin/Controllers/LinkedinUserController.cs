using AutoMapper;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Mvc;
using TinyServices.API.Linkedin.AppService;
using TinyServices.API.Linkedin.Dto;
using TinyServices.API.Linkedin.Model;

namespace TinyServices.API.Linkedin.Controllers;

[ApiController]
[Route("[controller]")]
public class LinkedinUserController : Controller
{
    private readonly LinkedinUserAppService service;
    private readonly IMapper mapper;

    public LinkedinUserController(LinkedinUserAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }

    [HttpPost]
    public LinkedinUserDto Create([FromBody] CreateLinkedinUserInput input)
    {
        var user = service.Create(input.UserName, input.PassWord, input.Email);
        var dto = mapper.Map<LinkedinUserDto>(user);
        return dto;
    }
    [HttpPut]
    [Route("{senderId:guid}/connectionRequest/{receiverId:guid}")]
    public ConnectionRequestDto SendConnectionRequest(Guid senderId, Guid receiverId)
    {
        var connectionRequest = service.SendConnectionRequest(senderId, receiverId);
        var dto = mapper.Map<ConnectionRequestDto>(connectionRequest);
        return dto;
    }

    [HttpPut]
    [Route("connection/{id:guid}/accept")]
    public ConnectionDto AcceptConnectRequest(Guid id)
    {
        var connection = service.AcceptConnectRequest(id);
        var dto = mapper.Map<ConnectionDto>(connection);
        return dto;
    }

    [HttpDelete]
    [Route("connection/{id:guid}/reject")]
    public void RejectConnectRequest(Guid id)
    {
        service.RejectConnectRequest(id);
    }

}

