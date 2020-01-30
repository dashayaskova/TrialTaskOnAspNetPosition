using DbEntities;
using ShopApiTestTask.Models;

namespace ShopApiTestTask.Mappers
{
	public class ItemToItemEntityService : IMapper<ItemView, Item>
	{
		public Item Map(ItemView item)
		{
			var dbItem = new Item();
			dbItem.Name = item.Name;
			dbItem.Category = item.Category;
			return dbItem;
		}
	}
}