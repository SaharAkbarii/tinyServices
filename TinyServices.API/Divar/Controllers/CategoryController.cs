using System.Data.Common;
using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TinyServices.API.Divar.AppService;
using TinyServices.API.Divar.Dto;
using TinyServices.API.Divar.Model;
using TinyServices.API.Migrations;

namespace TinyServices.API.Divar.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : Controller
{
    private readonly CategoryAppService service;
    private readonly IMapper mapper;

    public CategoryController (CategoryAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }

    [HttpPost]
    public CategoryDto Create([FromBody] CreateCategoryInput input)
    {
        var category = service.Create(input.Name);
        var dto = mapper.Map<CategoryDto>(category);
        return dto;
    }

    [HttpPut]
    [Route("{id:guid}/property/add")]
    public CategoryDto AddProperty(Guid id,[FromBody] CreateCategoryPropertyInput input)
    {
        // api input = CategoryPropertyDto
        // service input = AddPropertyRequest
        var request= input.Properties.Select(x=> new AddPropertyRequest(x.Title, x.IsMandatory)).ToList();
        var category= service.AddProperty(request, id);
        var dto = mapper.Map<CategoryDto>(category);
        return dto;
    }
    [HttpGet]
    [Route("GetAll")]
    public SearchResultDto<CategoryDto> GetAll(int count, int offset)
    {
        var categories = service.GetAll(count, offset);
        var dto = mapper.Map<SearchResultDto<CategoryDto>>(categories);
        return dto;
    }

    [HttpGet]
    [Route("{id:guid}")]
    public CategoryDto Search(Guid id)
    {
        var category= service.Search(id);
        var dto = mapper.Map<CategoryDto>(category);
        return dto;
    }

}
