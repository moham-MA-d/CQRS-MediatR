using AutoMapper;
using CQRS_MediatR.Commands;
using CQRS_MediatR.DataStore;
using CQRS_MediatR.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.Handlers
{
    // Unit: in MediatR Unit represents a void type.
    //public class AddProductHandler : IRequestHandler<AddProductCommand, Unit>
    //{
    //	private readonly ProductDataStore _productDataStore;

    //	public AddProductHandler(ProductDataStore productDataStore) => _productDataStore = productDataStore;

    //	public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
    //	{
    //		await _productDataStore.AddProduct(request.Product);

    //		 Unit.Value: is the only calue for the unit read-only struct.
    //		return Unit.Value;
    //	}
    //}

    public class AddProductHandler : IRequestHandler<AddProductCommand, ProductResponse>
    {
        private readonly ProductDataStore _productDataStore;
        private readonly IMapper _mapper;

        public AddProductHandler(ProductDataStore productDataStore, IMapper mapper)
        {
            _productDataStore = productDataStore;
            _mapper = mapper;
        } 

        public async Task<ProductResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _productDataStore.AddProduct(request.Product);
            var p = _mapper.Map<ProductResponse>(request.Product);
            return p;
        }
    }
}
