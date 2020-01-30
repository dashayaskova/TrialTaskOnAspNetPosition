using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DbEntities
{
	[DataContract]
	public class Item
	{
		[DataMember]
		private long _id;

		[DataMember]
		private string _name;

		[DataMember]
		private string _category;

		[DataMember]
		private Store _store;

		[DataMember]
		private string _storeName;

		public string Name { get => _name; set => _name = value; }
		public string Category { get => _category; set => _category = value; }
		public string StoreName { get => _storeName; set => _storeName = value; }
		public long Id { get => _id; set => _id = value; }
		public Store Store { get => _store; set => _store = value; }

		public Item()
		{

		}
	}
}
