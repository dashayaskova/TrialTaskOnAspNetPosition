using DbEntities;
using ShopApiTestTask.Models;
using ShopApiTestTask.Mappers.DeliveryService;
using ShopApiTestTask.Mappers.StoreService;
using ShopApiTestTask.Mappers.ItemService;

namespace ShopApiTestTask.Mappers
{
	public class MapperService : IMapperService
	{
		private readonly IDeliveryMapperService _deliveryService;
		private readonly IStoreMapperService _storeService;
		private readonly IItemMapperService _itemService;

		public MapperService(IDeliveryMapperService deliveryService,
			IStoreMapperService storeService, IItemMapperService itemService)
		{
			_deliveryService = deliveryService;
			_storeService = storeService;
			_itemService = itemService;
		}

		public Store Map(StoreViewModel entity)
		{
			var store = _storeService.Map(entity);

			foreach (var s in entity.Deliveries)
			{
				var del = Map(s);
				del.StoreName = store.Name;
				store.Deliveries.Add(del);
			}

			foreach (var i in entity.Items)
			{
				var item = Map(i);
				item.StoreName = store.Name;
				store.Items.Add(item);
			}

			return store;
		}

		public StoreViewModel Map(Store entity)
		{
			var storeViewModel = _storeService.Map(entity);

			foreach (var s in entity.Deliveries)
			{
				storeViewModel.Deliveries.Add(Map(s));
			}

			foreach (var i in entity.Items)
			{
				storeViewModel.Items.Add(Map(i));
			}

			return storeViewModel;
		}

		public DeliveryStore Map(DeliveryViewModel entity)
		{
			return _deliveryService.Map(entity);
		}

		public DeliveryViewModel Map(DeliveryStore entity)
		{
			return _deliveryService.Map(entity);
		}

		public ItemViewModel Map(Item entity)
		{
			return _itemService.Map(entity);
		}

		public Item Map(ItemViewModel entity)
		{
			return _itemService.Map(entity);
		}
	}
}