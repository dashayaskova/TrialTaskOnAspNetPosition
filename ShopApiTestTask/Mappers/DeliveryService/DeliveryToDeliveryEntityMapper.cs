using DbEntities;
using ShopApiTestTask.Models;

namespace ShopApiTestTask.Mappers
{
	public class DeliveryToDeliveryEntityMapper : IMapper<DeliveryViewModel, DeliveryStore>
	{
		public DeliveryStore Map(DeliveryViewModel delivery)
		{
			var deliveryDb = new DeliveryStore();
			deliveryDb.DeliveryId = delivery.Id;
			deliveryDb.Description = delivery.Description;
			deliveryDb.Price = delivery.Price;
			deliveryDb.State = delivery.State;
			return deliveryDb;
		}
	}
}