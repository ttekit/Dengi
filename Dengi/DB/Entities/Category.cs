using System.Collections.Generic;

namespace Dengi.DB.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public List<Category> SubCategories { get; set; }

    public override string ToString()
    {
        return Name;
    }
}