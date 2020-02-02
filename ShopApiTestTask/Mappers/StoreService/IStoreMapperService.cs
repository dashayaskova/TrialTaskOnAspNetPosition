using DbEntities;
using ShopApiTestTask.Models;

namespace ShopApiTestTask.Mappers.StoreService
{
	public interface IStoreMapperService : IMapper<StoreViewModel, Store>, IMapper<Store, StoreViewModel>
	{
	}
}
