using Catalog.Application.Product.Commands;
using Catalog.Application.Product.Responses;

namespace Catalog.Application.Product.Actor;

public class CreateProductActor : ReceiveActor
{
    private readonly IProductRepository repository;

    public CreateProductActor(IProductRepository repository)
    {
        this.repository = repository;

        ReceiveAsync<CreateProductCommand>(async command =>
        {
            var product = new Core.Entities.Product
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

            // Return result
            Sender.Tell(new CreateProductResult(product.Id));
        });
    }
}
