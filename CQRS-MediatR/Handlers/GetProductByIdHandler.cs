using CQRS_MediatR.DataStore;
using CQRS_MediatR.DTO;
using CQRS_MediatR.Queries;
using MediatR;

namespace CQRS_MediatR.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
	{
		private readonly ProductDataStore _productDataStore;

		public GetProductByIdHandler(ProductDataStore productDataStore) => _productDataStore = productDataStore;

		public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
			await _productDataStore.GetProductById(request.Id);
		
	}
}
