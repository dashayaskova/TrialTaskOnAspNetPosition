
using DbEntities;
using ShopApiTestTask.Models;
using System.Threading.Tasks;

namespace ShopApiTestTask.Services
{
	public interface IStoreService
	{
		Task<StoreViewModel> AddStore(StoreViewModel store);
		Task<StoreViewModel> EditStore(StoreViewModel store);
		Task<bool> StoreExists(StoreViewModel store);
		Task<Store> GetStore(StoreViewModel store);
	}
}
