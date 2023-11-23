using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TinyServices.API.NewsMagazine.AppService;
using TinyServices.API.NewsMagazine.Dto;

namespace TinyServices.API.NewsMagazine.Controllers;
[ApiController]
[Route("[controller]")]
public class NewsCategoryController : Controller
{
    private readonly NewsCategoryAppService service;
    private readonly IMapper mapper;

    public NewsCategoryController(NewsCategoryAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }
    [HttpPost]
    public NewsCategoryDto Create([FromBody] CreateNewsCategoryInput input)
    {
        var category = service.Create(input.Name);

        var dto = mapper.Map<NewsCategoryDto>(category);
        return dto;
    }
}
