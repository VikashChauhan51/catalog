using Catalog.Application.Product.Actors;
using Catalog.Application.Product.Queries;
using Catalog.Application.Product.Responses;

namespace Catalog.Application.Product.Handlers;
public class GetProductByCategoryQueryHandler
    : IQueryHandler<GetProductByCategoryQuery, Result<GetProductByCategoryResult>>
{
    private readonly IActorRef getProductActor;
    private readonly ILogger<GetProductByCategoryQueryHandler> logger;
    public GetProductByCategoryQueryHandler(ActorSystem actorSystem, ILogger<GetProductByCategoryQueryHandler> logger)
    {
        var props = DependencyResolver.For(actorSystem).Props<GetProductByCategoryActor>();
        getProductActor = actorSystem.ActorOf(props, "getProductByCategoryActor");
        this.logger = logger;
    }
    public async Task<Result<GetProductByCategoryResult>> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Fetcing product by category: {category}", query.Category);
        return await getProductActor.Ask<Result<GetProductByCategoryResult>>(query, cancellationToken).ConfigureAwait(false);
    }
}
