using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbEntities;
using ShopApiTestTask.Models;

namespace ShopApiTestTask.Mappers.ItemService
{
	public class ItemMapperService : IItemMapperService
	{
		private readonly IMapper<ItemViewModel, Item> _itemToItemEntityMapper;
		private readonly IMapper<Item, ItemViewModel> _itemEntityToItemMapper;


		public ItemMapperService(IMapper<Item, ItemViewModel> itemToItemEntity,
			IMapper<ItemViewModel, Item> itemEntityToItem)
		{
			_itemToItemEntityMapper = itemEntityToItem;
			_itemEntityToItemMapper = itemToItemEntity;
		}
		public ItemViewModel Map(Item entity)
		{
			return _itemEntityToItemMapper.Map(entity);
		}

		public Item Map(ItemViewModel entity)
		{
			return _itemToItemEntityMapper.Map(entity);
		}
	}
}