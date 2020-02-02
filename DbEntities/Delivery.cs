using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DbEntities
{
	[DataContract]
	public class Delivery: IStateObject
	{
		[DataMember]
		private long _id;

		[DataMember]
		private string _name;

		[IgnoreDataMember]
		private List<DeliveryStore> _stores;

		[IgnoreDataMember]
		private State _state;

		public long Id { get => _id; set => _id = value; }
		public string Name { get => _name; set => _name = value; }

		public List<DeliveryStore> Stores { get => _stores; set => _stores = value; }

		public State State { get => _state; set => _state = value; }

		public Delivery() { Stores = new List<DeliveryStore>(); }

		public Delivery(long id)
		{
			Id = id;
			Stores = new List<DeliveryStore>();
		}
	}
}
