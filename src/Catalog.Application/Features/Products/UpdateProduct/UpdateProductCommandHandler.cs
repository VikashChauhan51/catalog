namespace Catalog.Application.Features.Products.UpdateProduct;
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
