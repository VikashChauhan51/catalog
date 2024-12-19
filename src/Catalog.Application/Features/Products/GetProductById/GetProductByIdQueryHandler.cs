namespace Catalog.Application.Features.Products.GetProductById;
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
