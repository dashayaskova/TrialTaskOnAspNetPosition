using System.Collections.Generic;

namespace ShopApiTestTask.Models
{
	public class StoreViewModel
	{
		public string Name { get; set; }
		public string Country { get; set; }
		public string Currency { get; set; }
		public List<ItemViewModel> Items { get; set; }
		public List<DeliveryViewModel> Deliveries { get; set; }
		public string Username { get; set; }
	}
}