namespace DbProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ignoreProp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.delivery", "State");
            DropColumn("dbo.delivery_store", "State");
            DropColumn("dbo.store", "State");
            DropColumn("dbo.item", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.item", "State", c => c.Int(nullable: false));
            AddColumn("dbo.store", "State", c => c.Int(nullable: false));
            AddColumn("dbo.delivery_store", "State", c => c.Int(nullable: false));
            AddColumn("dbo.delivery", "State", c => c.Int(nullable: false));
        }
    }
}
