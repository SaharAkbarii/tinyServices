using TinyServices.API.Divar.Model;

namespace TinyServices.API.NewsMagazine.Dto;
public class NewsUserDto
{
    public string Email { get; set; }
    public string Name { get; set; }
    public Guid Id { get; set; }
    public List<FavoriteCategoryDto> FavoriteCategories { get; set; }
}
