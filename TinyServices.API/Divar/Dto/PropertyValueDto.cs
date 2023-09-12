namespace TinyServices.API.Divar.Dto;
public record PropertyValueDto(CategoryPropertyDto Property, string Value);

public record PropertyValueInput(Guid PropertyId, string Value);

