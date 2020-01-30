using DbEntities;
using ShopApiTestTask.Models;


namespace ShopApiTestTask.Mappers
{
	interface IMapperService : IMapper<StoreView, Store>, IMapper<DeliveryView, DeliveryStore>,
		IMapper<ItemView, Item>
	{
	}
}