using Catalog.Application.Features.Products.Shared.Repositories;

namespace Catalog.Application.Features.Products.CreateProduct;

public class CreateProductActor : ReceiveActor
{
    private readonly IProductRepository repository;

    public CreateProductActor(IProductRepository repository)
    {
        this.repository = repository;

        ReceiveAsync<CreateProductCommand>(async command =>
        {
            var product = new Domain.Features.Products.Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System"
            };

            // Save to database
            await this.repository.AddAsync(product, CancellationToken.None);
        });
    }
}
