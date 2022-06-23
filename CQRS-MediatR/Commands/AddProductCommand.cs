using CQRS_MediatR.DTO;
using MediatR;

namespace CQRS_MediatR.Commands
{
	// because we are not going to return a value we don't specify return type
	//public record AddProductCommand(Product Product) : IRequest;
	public record AddProductCommand(CreateProductRequest Product) : IRequest<CreateProductRequest>;
}
