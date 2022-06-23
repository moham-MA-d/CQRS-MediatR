using AutoMapper;
using CQRS_MediatR.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_MediatR.DataStore
{
	public class ProductDataStore
	{
		private static List<Product> _products;
        private readonly IMapper _mapper;

        public ProductDataStore(IMapper mapper)
		{
			_products = new List<Product>
			{
				new Product { Id = 1, Name = "TV" },
				new Product { Id = 2, Name = "Laptop" },
				new Product { Id = 3, Name = "Cell Phone" }
			};
           _mapper = mapper;
        }

		public async Task AddProduct(CreateProductRequest createProductRequest)
		{
			var product = _mapper.Map<Product>(createProductRequest);

			_products.Add(product);
			await Task.CompletedTask;
		}

		public async Task<IEnumerable<ProductResponse>> GetAllProducts() {
			var productList = await Task.FromResult(_products);
			var productResponseList =  _mapper.Map<List<ProductResponse>>(productList);
			return productResponseList;
		}
		public async Task<ProductResponse> GetProductById(int id)
		{
			var product = await Task.FromResult(_products.Single(p => p.Id == id));
			var productResponse = _mapper.Map<ProductResponse>(product);
			return productResponse;
		}
		public async Task EventOccured(Product product, string evt)
		{
			_products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
			await Task.CompletedTask;
		}
	}
}
