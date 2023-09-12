namespace TinyServices.API.Divar.Dto;
public record CategoryDto(string Name, List<CategoryPropertyDto>? Properties, Guid Id);
