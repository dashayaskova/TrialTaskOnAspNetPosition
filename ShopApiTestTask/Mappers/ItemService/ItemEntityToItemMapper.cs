using DbEntities;
using ShopApiTestTask.Models;

namespace ShopApiTestTask.Mappers.ItemService
{
	public class ItemEntityToItemMapper : IMapper<Item, ItemViewModel>
	{
		public ItemViewModel Map(Item itemDb)
		{
			var item = new ItemViewModel();
			item.Id = itemDb.Id;
			item.Name = itemDb.Name;
			item.Category = itemDb.Category;
			return item;
		}
	}
}