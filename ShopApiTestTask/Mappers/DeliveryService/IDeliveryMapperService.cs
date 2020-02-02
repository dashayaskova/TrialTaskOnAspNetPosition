using DbEntities;
using ShopApiTestTask.Models;

namespace ShopApiTestTask.Mappers.DeliveryService
{
	public interface IDeliveryMapperService: IMapper<DeliveryStore, DeliveryViewModel>,
		IMapper<DeliveryViewModel, DeliveryStore>
	{
	}
}
