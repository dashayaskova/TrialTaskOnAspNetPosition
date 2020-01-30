namespace DbProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.delivery",
                c => new
                    {
                        delivery_id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.delivery_id);
            
            CreateTable(
                "dbo.delivery_store",
                c => new
                    {
                        delivery_id = c.Long(nullable: false),
                        store_name = c.String(nullable: false, maxLength: 128),
                        description = c.String(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.delivery_id, t.store_name })
                .ForeignKey("dbo.delivery", t => t.delivery_id, cascadeDelete: true)
                .ForeignKey("dbo.store", t => t.store_name, cascadeDelete: true)
                .Index(t => t.delivery_id)
                .Index(t => t.store_name);
            
            CreateTable(
                "dbo.store",
                c => new
                    {
                        store_name = c.String(nullable: false, maxLength: 128),
                        country = c.String(nullable: false, maxLength: 50),
                        currency = c.String(nullable: false, maxLength: 50),
                        username = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.store_name);
            
            CreateTable(
                "dbo.item",
                c => new
                    {
                        item_id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 100),
                        category = c.String(maxLength: 50),
                        store_name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.item_id)
                .ForeignKey("dbo.store", t => t.store_name, cascadeDelete: true)
                .Index(t => t.store_name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.delivery_store", "store_name", "dbo.store");
            DropForeignKey("dbo.item", "store_name", "dbo.store");
            DropForeignKey("dbo.delivery_store", "delivery_id", "dbo.delivery");
            DropIndex("dbo.item", new[] { "store_name" });
            DropIndex("dbo.delivery_store", new[] { "store_name" });
            DropIndex("dbo.delivery_store", new[] { "delivery_id" });
            DropTable("dbo.item");
            DropTable("dbo.store");
            DropTable("dbo.delivery_store");
            DropTable("dbo.delivery");
        }
    }
}
