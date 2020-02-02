using DbEntities;
using ShopApiTestTask.Models;

namespace ShopApiTestTask.Mappers
{
	public class ItemToItemEntityMapper : IMapper<ItemViewModel, Item>
	{
		public Item Map(ItemViewModel item)
		{
			var dbItem = new Item();
			dbItem.Id = item.Id;
			dbItem.Name = item.Name;
			dbItem.Category = item.Category;
			return dbItem;
		}
	}
}