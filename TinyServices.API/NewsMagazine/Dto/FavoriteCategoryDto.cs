namespace TinyServices.API.NewsMagazine.Dto;

public class FavoriteCategoryDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
}
