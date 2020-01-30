using DbEntities;
using System.Data.Entity.ModelConfiguration;

namespace DbProvider.Configurations
{
	class DeliveryConfiguration : EntityTypeConfiguration<Delivery>
	{
		public DeliveryConfiguration()
		{
			ToTable("delivery");
			HasKey(delivery => delivery.Id);
			Property(delivery => delivery.Id).HasColumnName("delivery_id").IsRequired();
			Property(delivery => delivery.Name).HasMaxLength(50).HasColumnName("name").IsRequired();
		}
	}
}
