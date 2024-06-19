
namespace Catalog.Application.Handlers;
public class UpdateProductCommandHandler(ILogger<UpdateProductCommandHandler> logger, IDocumentSession session)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
        {
            logger.LogError("Product not found for id: {Id}", command.Id.ToString());
            throw new NotFoundException(command.Id.ToString());
        }

        product.Name = command.Name;
        product.Category = command.Category;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;
        product.LastModified = DateTime.UtcNow;
        product.LastModifiedBy = "System";

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}
