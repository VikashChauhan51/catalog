using Catalog.Application.Product.Actors;
using Catalog.Application.Product.Commands;

namespace Catalog.Application.Product.Handlers;
public class UpdateProductCommandHandler
    : ICommandHandler<UpdateProductCommand, Result<Unit>>
{
    private readonly IActorRef updateProductActor;
    public UpdateProductCommandHandler(ActorSystem actorSystem, ILogger<UpdateProductCommandHandler> logger)
    {
        var props = DependencyResolver.For(actorSystem).Props<UpdateProductActor>();
        updateProductActor = actorSystem.ActorOf(props, "updateProductActor");
    }
    public Task<Result<Unit>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        updateProductActor.Tell(command);
        return Task.FromResult(Result<Unit>.Succ(Unit.Value));
    }
}
