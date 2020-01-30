using DbEntities;
using System.Data.Entity.ModelConfiguration;

namespace DbProvider.Configurations
{
	class StoreConfiguration : EntityTypeConfiguration<Store>
	{
		public StoreConfiguration()
		{
			ToTable("store");
			HasKey(store => store.Name);
			Property(store => store.Name).HasColumnName("store_name").IsRequired();
			Property(store => store.Country).HasMaxLength(50).HasColumnName("country").IsRequired();
			Property(store => store.Currency).HasMaxLength(50).HasColumnName("currency").IsRequired();
			Property(store => store.Username).HasMaxLength(50).HasColumnName("username").IsRequired();
		}
	}
}
