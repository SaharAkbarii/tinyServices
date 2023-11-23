namespace TinyServices.API.NewsMagazine.Dto;
public class NewsCategoryDto
{
    public string Name { get; set; }
    public List<NewsDto> News { get; set; }
    public Guid Id { get; set; }
}

