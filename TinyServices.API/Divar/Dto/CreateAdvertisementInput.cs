namespace TinyServices.API.Divar.Dto;
public class CreateAdvertisementInput
{
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public int? Price { get; set; }
    public List<string>? UrlImage { get; set; }
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public string PhoneNumber { get; set; }
    public string? Description { get; set; }
    public List<PropertyValueInput> PropertyValues { get; set; }
    public Guid UserId {get; set;}
}
