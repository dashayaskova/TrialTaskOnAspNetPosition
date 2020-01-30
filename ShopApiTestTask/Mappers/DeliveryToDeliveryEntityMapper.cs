using DbEntities;
using ShopApiTestTask.Models;

namespace ShopApiTestTask.Mappers
{
	public class DeliveryToDeliveryEntityMapper : IMapper<DeliveryView, DeliveryStore>
	{
		public DeliveryStore Map(DeliveryView delivery)
		{
			var deliveryDb = new DeliveryStore();
			deliveryDb.DeliveryId = delivery.Id;
			deliveryDb.Description = delivery.Description;
			deliveryDb.Price = delivery.Price;
			return deliveryDb;
		}
	}
}