namespace Catalog.API.Endpoints.Features.Products.Shared;

public class ProductDto
{
    public required string Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<string> Category { get; set; } = [];
    public string Description { get; set; } = string.Empty;
    public string ImageFile { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
