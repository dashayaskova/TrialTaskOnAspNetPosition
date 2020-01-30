using DbEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DbProvider.Configurations
{
	class ItemConfiguration : EntityTypeConfiguration<Item>
	{
		public ItemConfiguration()
		{
			ToTable("item");
			HasKey(item => item.Id);
			Property(item => item.Id).HasColumnName("item_id").IsRequired();
			Property(item => item.Category).HasMaxLength(50).HasColumnName("category");
			Property(item => item.Name).HasMaxLength(100).HasColumnName("name").IsRequired();
			Property(item => item.StoreName).HasMaxLength(100).HasColumnName("store_name").IsRequired();
			HasRequired(item => item.Store).WithMany(store => store.Items).HasForeignKey(item => item.StoreName);
		}
	}
}
