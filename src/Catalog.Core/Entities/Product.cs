namespace Catalog.Core.Entities;
public class Product : Entity<string>
{
    public string Name { get; set; } = string.Empty;
    public List<string> Category { get; set; } = new();
    public string Description { get; set; } = string.Empty;
    public string ImageFile { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
