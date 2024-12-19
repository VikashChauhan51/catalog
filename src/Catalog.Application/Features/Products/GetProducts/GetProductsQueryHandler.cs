using Catalog.Application.Features.Products.GetProductById;

namespace Catalog.Application.Features.Products.GetProducts;
public class GetProductsQueryHandler
    : IQueryHandler<GetProductsQuery, Result<GetProductsResult>>
{
    private readonly IActorRef getProductsActor;
    private readonly ILogger<GetProductsQueryHandler> logger;
    public GetProductsQueryHandler(ActorSystem actorSystem, ILogger<GetProductsQueryHandler> logger)
    {
        var props = DependencyResolver.For(actorSystem).Props<GetProductByIdActor>();
        getProductsActor = actorSystem.ActorOf(props, "getProductsActor");
        this.logger = logger;
    }
    public async Task<Result<GetProductsResult>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting products for page: {Page}", query.PageNumber + 1);
        return await getProductsActor.Ask<Result<GetProductsResult>>(query, cancellationToken).ConfigureAwait(false);
    }
}
