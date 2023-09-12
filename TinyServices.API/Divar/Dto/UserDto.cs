namespace TinyServices.API.Divar.Dto;
public record UserDto(string Name, string Email, string PhoneNumber, Guid Id, List<AdvertisementDto>? Advertisements);
