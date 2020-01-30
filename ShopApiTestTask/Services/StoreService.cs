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
	public class StoreService: IStoreService
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

			dbStore.Country = newdbStore.Country;
			dbStore.Currency = newdbStore.Currency;

			UpdateStoreDeliveries(newdbStore.Deliveries, dbStore);
			//UpdateItems

			await _context.SaveChangesAsync();
			return dbStore;
		}

		private void UpdateStoreDeliveries(List<DeliveryStore> newDeliveries, Store storeToUpdate)
		{
			if (newDeliveries == null)
			{
				storeToUpdate.Deliveries = new List<DeliveryStore>();
				return;
			}

			var newDeliveriesHS = new HashSet<long>(newDeliveries.Select(o => o.DeliveryId));
			var storeDeliveriesHS = new HashSet<long>(storeToUpdate.Deliveries.Select(o => o.DeliveryId));

			foreach (var delivery in _context.Delivery)
			{	
				if (newDeliveriesHS.Contains(delivery.Id))
				{
					var delStore = newDeliveries.FirstOrDefault(o => o.DeliveryId == delivery.Id);

					if (!storeDeliveriesHS.Contains(delivery.Id))
					{
						storeToUpdate.Deliveries.Add(delStore);
					}
					else
					{
						var foundDel = storeToUpdate.Deliveries.FirstOrDefault(o => o.DeliveryId == delivery.Id);
						foundDel.Description = delStore.Description;
						foundDel.Price = delStore.Price;
					}
				}
				else
				{
					if (storeDeliveriesHS.Contains(delivery.Id))
					{
						storeToUpdate.Deliveries.Remove(
							storeToUpdate.Deliveries.First(o => o.DeliveryId == delivery.Id));
					}
				}
			}
		}
	}
}