using Catalog.Domain.Core;

namespace Catalog.Application.Core.Repositories;
public interface IRepository<T, TKey> : IReadRepository<T, TKey>, IWriteRepository<T, TKey> where T : IEntity where TKey : notnull
{

}

