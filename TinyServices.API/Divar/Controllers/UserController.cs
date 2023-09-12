using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TinyServices.API.Divar.AppService;
using TinyServices.API.Divar.Dto;
using TinyServices.API.Divar.Model;

namespace TinyServices.API.Divar.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly UserAppService service;
    private readonly IMapper mapper;

    public UserController(UserAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }

    [HttpPost]
    public UserDto Create([FromBody] CreateUserInput input)
    {
        var user = service.Create(input.Name, input.Email, input.PhoneNumber);
        var dto = mapper.Map<UserDto>(user);
        return dto;
    }

    [HttpGet]
    [Route("{id:guid}")]
    public UserDto Search(Guid id)
    {
        var user = service.Search(id);
        var dto = mapper.Map<UserDto>(user);
        return dto;
    }

}