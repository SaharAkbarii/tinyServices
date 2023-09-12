using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Divar.Model;

public class PropertyValue : Entity
{
    protected PropertyValue()
    {

    }
    public PropertyValue(CategoryProperty property, string value)
    {
        Property = property;
        Value = value;
    }

    public CategoryProperty Property {get; set;}
    public string Value { get; set; }
    public Advertisement Advertisement { get; set; }

}
