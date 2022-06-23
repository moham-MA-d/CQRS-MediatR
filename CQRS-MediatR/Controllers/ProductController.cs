using CQRS_MediatR.Commands;
using CQRS_MediatR.DTO;
using CQRS_MediatR.Notifications;
using CQRS_MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		// IMediator allows us to send message to mediatR which then dispatches them into relevant handler.
		// Since MediatR v.9 is splited into two interfaces: ISender, IPublisher. If we want to be more strict about it
		// we can use these new interfaces.

		private readonly ISender _sender;
		private readonly IPublisher _publisher;

        public ProductsController(ISender sender, IPublisher publisher)
        {
			_sender = sender;
			_publisher = publisher;
        }

        [HttpGet]
		public async Task<ActionResult> GetProducts()
		{
			// Send() is request/response approach
			var products = await _sender.Send(new GetProductsQuery());

			return Ok(products);
		}

		[HttpGet("{id:int}", Name = "GetProductById")]
		public async Task<ActionResult> GetProductById(int id)
		{
			var product = await _sender.Send(new GetProductByIdQuery(id));

			return Ok(product);
		}

		[HttpPost]
		public async Task<ActionResult> AddProduct([FromBody] CreateProductRequest product)
		{
			var productToReturn = await _sender.Send(new AddProductCommand(product));

			await _publisher.Publish(new ProductAddedNotification(productToReturn));

			return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
		}
	}
	
}
