using Catalog.Application.Features.Products.UpdateProduct;

namespace Catalog.Application.Features.Products.CreateProduct;


public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Unit>>
{
    private readonly IActorRef createProductActor;

    private readonly ILogger<UpdateProductCommandHandler> logger;
    public CreateProductCommandHandler(ActorSystem actorSystem, ILogger<UpdateProductCommandHandler> logger)
    {
        var props = DependencyResolver.For(actorSystem).Props<CreateProductActor>();
        createProductActor = actorSystem.ActorOf(props, "createProductActor");
        this.logger = logger;
    }

    public Task<Result<Unit>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating product.");
        createProductActor.Tell(command);
        return Task.FromResult(Result<Unit>.Succ(Unit.Value));
    }
}

