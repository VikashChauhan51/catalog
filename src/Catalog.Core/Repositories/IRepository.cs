using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;
public interface IRepository<T, TKey> : IReadRepository<T, TKey>, IWriteRepository<T, TKey> where T : IEntity where TKey : notnull
{

}

