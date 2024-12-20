﻿namespace Catalog.Domain.Core;
public class PaginatedResult<TEntity>
(
    long Count,
    long PageNumber,
    long PageSize,
    long PageCount,
    long TotalItemCount,
    bool HasPreviousPage,
    bool HasNextPage,
    bool IsFirstPage,
    bool IsLastPage,
    IEnumerable<TEntity> entities
) where TEntity : IEntity;
