using CQRS_MediatR.DataStore;
using CQRS_MediatR.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.Handlers
{
	public class EmailHandler : INotificationHandler<ProductAddedNotification>
	{
		private readonly ProductDataStore _productDataStore;

		public EmailHandler(ProductDataStore productDataStore) => _productDataStore = productDataStore;

		public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
		{
			//await _productDataStore.EventOccured(notification.Product, "Email sent");
			await Task.CompletedTask;
		}
	}
}
