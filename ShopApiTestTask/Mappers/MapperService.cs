using DbEntities;
using ShopApiTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopApiTestTask.Mappers
{
	public class MapperService : IMapperService
	{
		private readonly IMapper<StoreView, Store> _storeToStoreEntityMapper;
		private readonly IMapper<DeliveryView, DeliveryStore> _deliveryToDeliveryEntityMapper;
		private readonly IMapper<ItemView, Item> _itemToItemEntityMapper;

		public MapperService(IMapper<StoreView, Store> storeToStoreEntityMapper, 
			IMapper<DeliveryView, DeliveryStore> deliveryToDeliveryEntityMapper,
			IMapper<ItemView, Item> itemToItemEntityMapper)
		{
			_storeToStoreEntityMapper = storeToStoreEntityMapper ?? throw new ArgumentNullException(nameof(storeToStoreEntityMapper));
			_deliveryToDeliveryEntityMapper = deliveryToDeliveryEntityMapper ?? throw new ArgumentNullException(nameof(deliveryToDeliveryEntityMapper));
			_itemToItemEntityMapper = itemToItemEntityMapper ?? throw new ArgumentNullException(nameof(itemToItemEntityMapper));
		}

		public Store Map(StoreView entity)
		{
			var store = _storeToStoreEntityMapper.Map(entity);

			foreach (var s in entity.Deliveries)
			{
				var newSt = Map(s);
				newSt.StoreName = store.Name;
				store.Deliveries.Add(newSt);
			}

			foreach (var i in entity.Items)
			{
				store.Items.Add(Map(i));
			}

			return store;
		}

		public DeliveryStore Map(DeliveryView entity)
		{
			return _deliveryToDeliveryEntityMapper.Map(entity);
		}

		public Item Map(ItemView entity)
		{
			return _itemToItemEntityMapper.Map(entity);
		}
	}
}