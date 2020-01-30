
using DbEntities;
using ShopApiTestTask.Models;
using System.Threading.Tasks;

namespace ShopApiTestTask.Services
{
	public interface IStoreService
	{
		Task<Store> AddStore(StoreView store);
		Task<Store> EditStore(StoreView store);
		Task<bool> StoreExists(StoreView store);
		Task<Store> GetStore(StoreView store);
	}
}
