namespace TinyServices.API.Divar.Dto;
public record AdvertisementDto (
    Guid CategoryId, 
    string Title, 
    string City, 
    string Neighborhood, 
    string PhoneNumber, 
    List<PropertyValueDto> PropertyValues,
    Guid UserId);

