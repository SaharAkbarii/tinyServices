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

}