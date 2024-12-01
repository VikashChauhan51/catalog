using Catalog.Application.Product.Actor;
using Catalog.Application.Product.Commands;
using Catalog.Application.Product.Responses;


namespace Catalog.Application.Product.Handlers;


public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IActorRef createProductActor;

    public CreateProductCommandHandler(ActorSystem actorSystem)
    {
        var props = DependencyResolver.For(actorSystem).Props<CreateProductActor>();
        createProductActor = actorSystem.ActorOf(props, "createProductActor");
    }

    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var result = await this.createProductActor.Ask<CreateProductResult>(command, cancellationToken);
        return result;
    }
}

