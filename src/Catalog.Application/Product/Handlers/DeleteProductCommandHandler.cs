using Catalog.Application.Product.Actors;
using Catalog.Application.Product.Commands;

namespace Catalog.Application.Product.Handlers;
public class DeleteProductCommandHandler
    : ICommandHandler<DeleteProductCommand, Result<Unit>>
{
    private readonly IActorRef deleteProductActor;
    private readonly ILogger<DeleteProductCommandHandler> logger;
    public DeleteProductCommandHandler(ActorSystem actorSystem, ILogger<DeleteProductCommandHandler> logger)
    {
        var props = DependencyResolver.For(actorSystem).Props<DeleteProductActor>();
        deleteProductActor = actorSystem.ActorOf(props, "deleteProductActor");
        this.logger = logger;
    }

    public Task<Result<Unit>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Deleting product.");
        deleteProductActor.Tell(command);

        return Task.FromResult(Result<Unit>.Succ(Unit.Value));
    }
}
