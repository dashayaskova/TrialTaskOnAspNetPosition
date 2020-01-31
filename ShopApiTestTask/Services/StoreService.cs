using DbEntities;
using DbProvider.Context;
using ShopApiTestTask.Mappers;
using ShopApiTestTask.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApiTestTask.Services
{
	public class StoreService : IStoreService
	{
		private IStoreContext _context = new StoreContext();
		private IMapperService _mapperService = new MapperService(new StoreToStoreEntityMapper(),
			new DeliveryToDeliveryEntityMapper(), new ItemToItemEntityService());

		#region Constructors
		public StoreService() { }

		public StoreService(IStoreContext context)
		{
			_context = context;
		}

		#endregion

		public async Task<bool> StoreExists(StoreView store)
		{
			return await _context.Stores.CountAsync(o => o.Name == store.Name) != 0;
		}

		public async Task<Store> GetStore(StoreView store)
		{
			return await _context.Stores
				.Include(o => o.Deliveries)
				.Include(o => o.Items)
				.FirstOrDefaultAsync(o => o.Name == store.Name);
		}

		public async Task<Store> AddStore(StoreView store)
		{
			var newStore = _mapperService.Map(store);
			var output = _context.Stores.Add(newStore);
			await _context.SaveChangesAsync();

			return output;
		}

		public async Task<Store> EditStore(StoreView store)
		{
			var newdbStore = _mapperService.Map(store);
			var dbStore = await GetStore(store);
			_context.Entry(dbStore).CurrentValues.SetValues(newdbStore);
			UpdateStoreDeliveries(newdbStore, dbStore);
			//UpdateItems
			await _context.SaveChangesAsync();
			return dbStore;
		}

		private void UpdateStoreDeliveries(Store newStore, Store oldStore)
		{
			foreach (var delStore in oldStore.Deliveries.ToList())
				if (!newStore.Deliveries.Any(d => d.DeliveryId == delStore.DeliveryId))
					_context.DeliveryStores.Remove(delStore);

			foreach (var newDelStore in newStore.Deliveries)
			{
				var dbDelStore = oldStore.Deliveries.SingleOrDefault(d => d.DeliveryId == newDelStore.DeliveryId);
				if (dbDelStore != null)
					_context.Entry(dbDelStore).CurrentValues.SetValues(newDelStore);
				else
					oldStore.Deliveries.Add(newDelStore);
			}
		}
	}
}