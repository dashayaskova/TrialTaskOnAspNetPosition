using System;
using System.Data.Entity;
using DbEntities;
using DbProvider.Configurations;
using DbProvider.Migrations;

namespace DbProvider.Context
{
	public class StoreContext : DbContext, IStoreContext
	{
		public StoreContext() : base("TestStore")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreContext, Configuration>());
			Configuration.ProxyCreationEnabled = false;
		}

		public DbSet<Store> Stores { get; set; }

		public DbSet<DeliveryStore> DeliveryStores { get; set; }

		public DbSet<Item> Items { get; set; }

		public DbSet<Delivery> Delivery { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new DeliveryStoreConfiguration());
			modelBuilder.Configurations.Add(new DeliveryConfiguration());
			modelBuilder.Configurations.Add(new StoreConfiguration());
			modelBuilder.Configurations.Add(new ItemConfiguration());
		}
	}
}
