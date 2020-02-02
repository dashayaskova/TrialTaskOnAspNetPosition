using DbEntities;
using ShopApiTestTask.Models;

namespace ShopApiTestTask.Mappers.ItemService
{
	public interface IItemMapperService : IMapper<Item, ItemViewModel>,
		IMapper<ItemViewModel, Item>
	{
	}
}