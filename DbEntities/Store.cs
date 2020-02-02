using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DbEntities
{
	[DataContract]
	public class Store
	{
		[DataMember]
		private string _name;

		[DataMember]
		private string _country;

		[DataMember]
		private string _currency;

		[DataMember]
		private string _username;

		[IgnoreDataMember]
		private List<Item> _items;

		[IgnoreDataMember]
		private List<DeliveryStore> _deliveries;

		public string Name { get => _name; set => _name = value; }
		public string Country { get => _country; set => _country = value; }
		public string Currency { get => _currency; set => _currency = value; }
		public List<Item> Items { get => _items; set => _items = value; }
		public List<DeliveryStore> Deliveries { get => _deliveries; set => _deliveries = value; }
		public string Username { get => _username; set => _username = value; }


		public Store()
		{
			Items = new List<Item>();
			Deliveries = new List<DeliveryStore>();
		}

		public Store(string name)
		{
			Items = new List<Item>();
			Deliveries = new List<DeliveryStore>();
			Name = name;
		}
	}
}
