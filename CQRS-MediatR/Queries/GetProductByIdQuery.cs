using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_MediatR.Queries
{
	public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
