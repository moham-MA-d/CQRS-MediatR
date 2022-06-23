using AutoMapper;
using CQRS_MediatR.DTO;

namespace CQRS_MediatR.Helpers
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
            CreateMap<CreateProductRequest, ProductResponse>();
        }
    }
}
