using System.Collections.Generic;

namespace ShopApiTestTask.Models
{
	public class StoreView
	{
		public string Name { get; set; }
		public string Country { get; set; }
		public string Currency { get; set; }
		public List<ItemView> Items { get; set; }
		public List<DeliveryView> Deliveries { get; set; }
		public string Username { get; set; }
	}
}