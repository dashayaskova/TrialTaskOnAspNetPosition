using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DbEntities
{
	[DataContract(IsReference =true)]
	public class DeliveryStore: IDbEntity
	{
		[DataMember]
		private long _deliveryId;

		[DataMember]
		private Delivery _delivery;

		[DataMember]
		private string _description;

		[DataMember]
		private decimal _price;

		[DataMember]
		private string _storeName;

		[DataMember]
		private Store _store;

		public long DeliveryId { get => _deliveryId; set => _deliveryId = value; } 
		public string StoreName { get => _storeName; set => _storeName = value; }
		public Delivery Delivery { get => _delivery; set => _delivery = value; }
		public Store Store { get => _store; set => _store = value; }
		public string Description { get => _description; set => _description = value; }
		public decimal Price { get => _price; set => _price = value; }

		public DeliveryStore()
		{

		}
	}
}
