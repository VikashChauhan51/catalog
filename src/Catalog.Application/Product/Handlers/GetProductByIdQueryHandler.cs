using Catalog.Application.Product.Actors;
using Catalog.Application.Product.Queries;
using Catalog.Application.Product.Responses;

namespace Catalog.Application.Product.Handlers;
public class GetProductByIdQueryHandler
    : IQueryHandler<GetProductByIdQuery, Result<GetProductByIdResult>>
{
    private readonly IActorRef getByIdProductActor;
    private readonly ILogger<GetProductByIdQueryHandler> logger;
    public GetProductByIdQueryHandler(ActorSystem actorSystem, ILogger<GetProductByIdQueryHandler> logger)
    {
        var props = DependencyResolver.For(actorSystem).Props<GetProductByIdActor>();
        getByIdProductActor = actorSystem.ActorOf(props, "getByIdProductActor");
        this.logger = logger;
    }
    public async Task<Result<GetProductByIdResult>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting product.");
        return await getByIdProductActor.Ask<Result<GetProductByIdResult>>(query.Id, cancellationToken);
    }
}
