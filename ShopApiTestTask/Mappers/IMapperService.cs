using ShopApiTestTask.Mappers.DeliveryService;
using ShopApiTestTask.Mappers.ItemService;
using ShopApiTestTask.Mappers.StoreService;

namespace ShopApiTestTask.Mappers
{
	public interface IMapperService : IDeliveryMapperService, IStoreMapperService, IItemMapperService
	{
	}
}