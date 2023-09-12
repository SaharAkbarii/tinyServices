using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TinyServices.API.LinkService.Model;

namespace TinyServices.API.Divar.Model;

public class Category : Entity
{
    protected Category()
    {
        Properties = new List<CategoryProperty>();
    }
    public Category(string name)
    {
        Name = name;
        Properties = new List<CategoryProperty>();
    }

    public string Name { get; set; }
    public List<CategoryProperty>? Properties { get; set; }

}

