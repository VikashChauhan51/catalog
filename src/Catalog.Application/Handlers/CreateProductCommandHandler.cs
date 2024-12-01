namespace Catalog.Application.Handlers;
public class CreateProductCommandHandler(IProductRepository productRepository)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id=Guid.NewGuid().ToString(),
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System"
        };

        //save to database
        await productRepository.AddAsync(product,cancellationToken);

        //return result
        return new CreateProductResult(product.Id);
    }
}
