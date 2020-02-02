using DbEntities;
using System.Data.Entity.ModelConfiguration;

namespace DbProvider.Configurations
{
	class DeliveryStoreConfiguration : EntityTypeConfiguration<DeliveryStore>
	{
		public DeliveryStoreConfiguration()
		{
			ToTable("delivery_store");
			HasKey(ds => new { ds.DeliveryId, ds.StoreName });
			Property(ds => ds.DeliveryId).HasColumnName("delivery_id").IsRequired();
			Property(ds => ds.StoreName).HasColumnName("store_name").IsRequired();
			Property(ds => ds.Price).HasColumnName("price").IsRequired();
			Property(ds => ds.Description).HasColumnName("description").IsRequired();
			HasRequired(ds => ds.Delivery).WithMany(d => d.Stores)
				.HasForeignKey(ds => ds.DeliveryId);
			HasRequired(ds => ds.Store).WithMany(s => s.Deliveries)
				.HasForeignKey(ds => ds.StoreName);
			Ignore(ds => ds.State);
		}
	}
}
