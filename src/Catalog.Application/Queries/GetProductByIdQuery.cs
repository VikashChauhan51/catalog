using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries;
public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
