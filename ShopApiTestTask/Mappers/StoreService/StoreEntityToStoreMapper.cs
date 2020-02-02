using DbEntities;
using ShopApiTestTask.Models;
using System.Collections.Generic;

namespace ShopApiTestTask.Mappers
{
	public class StoreEntityToStoreMapper: IMapper<Store, StoreViewModel>
	{
		public StoreViewModel Map(Store dbStore)
		{
			var store = new StoreViewModel();
			store.Name = dbStore.Name;
			store.Country = dbStore.Country;
			store.Currency = dbStore.Currency;
			store.Username = dbStore.Username;
			store.Items = new List<ItemViewModel>();
			store.Deliveries = new List<DeliveryViewModel>();
			return store;
		}
	}
}