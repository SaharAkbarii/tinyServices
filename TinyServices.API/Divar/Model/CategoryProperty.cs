using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Divar.Model;

public class CategoryProperty : Entity
{
    protected CategoryProperty()
    {

    }
    public CategoryProperty(string title, bool isMandatory, Category category)
    {
        Title = title;
        IsMandatory = isMandatory;
        Category = category;
    }

    public string Title { get; set; }
    public bool IsMandatory { get; set; }
    public Category Category { get; set; }
}
