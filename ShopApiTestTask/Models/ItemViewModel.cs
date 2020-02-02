using DbEntities;

namespace ShopApiTestTask.Models
{
	public class ItemViewModel: IStateObject
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
		public State State { get; set; }
	}
}