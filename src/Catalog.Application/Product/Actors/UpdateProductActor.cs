using Catalog.Application.Product.Commands;

namespace Catalog.Application.Product.Actors;
internal class UpdateProductActor: ReceiveActor
{
    private readonly IProductRepository repository;

    public UpdateProductActor(IProductRepository repository)
    {
        this.repository = repository;

        ReceiveAsync<UpdateProductCommand>(async command =>
        {
            var product = new Core.Entities.Product
            {
                Id = command.Id,
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
                LastModified = DateTime.UtcNow,
                LastModifiedBy = "System"
            };

            await this.repository.UpdateAsync(product, CancellationToken.None);
        });
    }
}
