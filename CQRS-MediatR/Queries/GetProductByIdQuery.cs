using CQRS_MediatR.DTO;
using MediatR;

namespace CQRS_MediatR.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductResponse>;
}
