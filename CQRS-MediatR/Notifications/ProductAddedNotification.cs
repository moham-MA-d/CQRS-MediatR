using CQRS_MediatR.DTO;
using MediatR;

namespace CQRS_MediatR.Notifications
{
	public record ProductAddedNotification(ProductResponse Product) : INotification;
}
