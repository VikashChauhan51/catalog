using Ecart.Core.Domain;

namespace Catalog.Core.Entities;
public class Product : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public List<string> Category { get; set; } = new();
    public string Description { get; set; } = string.Empty;
    public string ImageFile { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
