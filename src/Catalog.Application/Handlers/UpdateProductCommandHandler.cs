
namespace Catalog.Application.Handlers;
public class UpdateProductCommandHandler(ILogger<UpdateProductCommandHandler> logger, IProductRepository productRepository)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product {
            Id = command.Id,
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
            LastModified = DateTime.UtcNow,
            LastModifiedBy = "System"
        };

        await productRepository.UpdateAsync(product, cancellationToken);

        return new UpdateProductResult(true);
    }
}
