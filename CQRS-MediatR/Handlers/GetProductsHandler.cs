using CQRS_MediatR.DataStore;
using CQRS_MediatR.DTO;
using CQRS_MediatR.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.Handlers
{
	// In here we handle GetProductsQuery and return IEnumerable<Product>
	public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductResponse>>
	{
		private readonly ProductDataStore _productDataStore;

		public GetProductsHandler(ProductDataStore productDataStore) => _productDataStore = productDataStore;

		public async Task<IEnumerable<ProductResponse>> Handle
			(GetProductsQuery request, CancellationToken cancellationToken) => await _productDataStore.GetAllProducts();
	}
}
