using CQRS_MediatR.DataStore;
using CQRS_MediatR.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.Handlers
{
	public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
	{
		private readonly ProductDataStore _productDataStore;

		public GetProductByIdHandler(ProductDataStore productDataStore) => _productDataStore = productDataStore;

		public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
			await _productDataStore.GetProductById(request.Id);
		
	}
}
