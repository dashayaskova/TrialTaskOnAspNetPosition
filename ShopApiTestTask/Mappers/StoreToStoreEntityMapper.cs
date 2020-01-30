using DbEntities;
using ShopApiTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopApiTestTask.Mappers
{
	public class StoreToStoreEntityMapper : IMapper<StoreView, Store>
	{
		public Store Map(StoreView store)
		{
			var dbStore = new Store();
			dbStore.Name = store.Name;
			dbStore.Country = store.Country;
			dbStore.Currency = store.Currency;
			dbStore.Username = store.Username;
			return dbStore;
		}
	}
}