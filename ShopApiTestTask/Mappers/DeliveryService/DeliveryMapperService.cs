using DbEntities;
using ShopApiTestTask.Models;

namespace ShopApiTestTask.Mappers.DeliveryService
{
	public class DeliveryMapperService:IDeliveryMapperService
	{
		private readonly IMapper<DeliveryViewModel, DeliveryStore> _storeToStoreEntityMapper;
		private readonly IMapper<DeliveryStore, DeliveryViewModel> _storeEntityToStoreMapper;

		public DeliveryMapperService(IMapper<DeliveryStore, DeliveryViewModel> deliveryToDeliveryEntity,
			IMapper<DeliveryViewModel, DeliveryStore> deliveryEntityToDelivery)
		{
			_storeToStoreEntityMapper = deliveryEntityToDelivery;
			_storeEntityToStoreMapper = deliveryToDeliveryEntity;
		}

		public DeliveryStore Map(DeliveryViewModel entity)
		{
			return _storeToStoreEntityMapper.Map(entity);
		}

		public DeliveryViewModel Map(DeliveryStore entity)
		{
			return _storeEntityToStoreMapper.Map(entity);
		}
	}
}