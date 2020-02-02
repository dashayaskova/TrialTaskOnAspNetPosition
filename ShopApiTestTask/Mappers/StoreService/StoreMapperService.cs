using DbEntities;
using ShopApiTestTask.Mappers.StoreService;
using ShopApiTestTask.Models;

namespace ShopApiTestTask.Mappers
{
	public class StoreMapperService:IStoreMapperService
	{
		private readonly IMapper<StoreViewModel, Store> _storeToStoreEntityMapper;
		private readonly IMapper<Store, StoreViewModel> _storeEntityToStoreMapper;

		public StoreMapperService(IMapper<Store, StoreViewModel> storeToStoreEntity,
	IMapper<StoreViewModel, Store> storeEntityToStore)
		{
			_storeToStoreEntityMapper = storeEntityToStore;
			_storeEntityToStoreMapper = storeToStoreEntity;
		}

		public Store Map(StoreViewModel entity)
		{
			return _storeToStoreEntityMapper.Map(entity);
		}

		public StoreViewModel Map(Store entity)
		{
			return _storeEntityToStoreMapper.Map(entity);
		}
	}
}
