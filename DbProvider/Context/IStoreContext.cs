using DbEntities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace DbProvider.Context
{
	public interface IStoreContext
	{
		DbSet<Store> Stores { get; }
		DbSet<DeliveryStore> DeliveryStores { get; }
		DbSet<Item> Items { get; }
		DbSet<Delivery> Delivery { get; }
		Task<int> SaveChangesAsync();
		DbEntityEntry Entry(object entity);
	}
}
