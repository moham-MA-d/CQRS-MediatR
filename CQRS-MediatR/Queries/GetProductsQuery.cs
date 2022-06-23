using CQRS_MediatR.DTO;
using MediatR;
using System.Collections.Generic;

namespace CQRS_MediatR.Queries
{
	public record GetProductsQuery() : IRequest<IEnumerable<ProductResponse>>;
}
