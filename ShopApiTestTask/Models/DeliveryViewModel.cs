
using DbEntities;

namespace ShopApiTestTask.Models
{
	public class DeliveryViewModel: IStateObject
	{
		public string Description { get; set; }
		public decimal Price { get; set; }
		public long Id { get; set; }
		public State State { get; set; }
	}
}