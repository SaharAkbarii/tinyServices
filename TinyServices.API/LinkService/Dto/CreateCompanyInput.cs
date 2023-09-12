namespace TinyServices.API.LinkService.Dto; 
public record CreateCompanyInput(string Name);
public record CompanyDto
{
    public string Name { get; set; }
    public Guid Id { get; set; }
    public List<ShortLinkDto> ShortLinks { get; set; }
}