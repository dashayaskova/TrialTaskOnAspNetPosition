using DbEntities;
using ShopApiTestTask.Models;

namespace ShopApiTestTask.Mappers.DeliveryService
{
	public class DeliveryEntityToDeliveryMapper:IMapper<DeliveryStore, DeliveryViewModel>
	{
		public DeliveryViewModel Map(DeliveryStore deliveryDb)
		{
			var delivery = new DeliveryViewModel();
			delivery.Id = deliveryDb.DeliveryId;
			delivery.Description = deliveryDb.Description;
			delivery.Price = deliveryDb.Price;
			delivery.State = deliveryDb.State;
			return delivery;
		}
	}
}