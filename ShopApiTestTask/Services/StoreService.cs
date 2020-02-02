using DbEntities;
using DbProvider.Context;
using ShopApiTestTask.Mappers;
using ShopApiTestTask.Mappers.DeliveryService;
using ShopApiTestTask.Mappers.ItemService;
using ShopApiTestTask.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApiTestTask.Services
{
	public class StoreService : IStoreService
	{
		private IStoreContext _context = new StoreContext();
		private IMapperService _mapperService = new MapperService(
			new DeliveryMapperService(new DeliveryEntityToDeliveryMapper(), new DeliveryToDeliveryEntityMapper()),
			new StoreMapperService(new StoreEntityToStoreMapper(), new StoreToStoreEntityMapper()),
			new ItemMapperService(new ItemEntityToItemMapper(), new ItemToItemEntityMapper())
			);

		#region Constructors
		public StoreService() { }

		public StoreService(IStoreContext context)
		{
			_context = context;
		}

		#endregion

		public async Task<bool> StoreExists(StoreViewModel store)
		{
			return await _context.Stores.CountAsync(o => o.Name == store.Name) != 0;
		}

		public async Task<Store> GetStore(StoreViewModel store)
		{
			return await _context.Stores
				.Include(o => o.Deliveries)
				.Include(o => o.Items)
				.FirstOrDefaultAsync(o => o.Name == store.Name);
		}

		public async Task<StoreViewModel> AddStore(StoreViewModel store)
		{
			var newStore = _mapperService.Map(store);
			var output = _context.Stores.Add(newStore);
			await _context.SaveChangesAsync();
			return _mapperService.Map(output);
		}

		public async Task<StoreViewModel> EditStore(StoreViewModel store) 
		{
			var newDbStore = _mapperService.Map(store);
			var existedDbStore = await GetStore(store);
			UpdateEntities(newDbStore, existedDbStore);
			await _context.SaveChangesAsync();
			return _mapperService.Map(newDbStore);
		}

		private void UpdateEntities(Store newDbStore, Store existedDbStore)
		{
			_context.Entry(existedDbStore).CurrentValues.SetValues(newDbStore);

			foreach (var newDel in newDbStore.Deliveries)
			{
				var curDel = existedDbStore.Deliveries.SingleOrDefault(o => o.DeliveryId == newDel.DeliveryId);
				UpdateEntity(newDel, curDel);
			}

			foreach (var newItem in newDbStore.Items)
			{
				var curItem = existedDbStore.Items.SingleOrDefault(d => d.Id == newItem.Id);
				UpdateEntity(newItem, curItem);
			}
		}

		private void UpdateEntity(IStateObject newEntity, IStateObject oldEntity)
		{
			if (oldEntity == null && newEntity.State == State.Added)
				_context.Entry(newEntity).State = EntityState.Added;

			if (oldEntity != null)
			{
				if (newEntity.State == State.Deleted)
					_context.Entry(oldEntity).State = EntityState.Deleted;
				else if (newEntity.State == State.Modified)
					_context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
			}
		}
	}
}