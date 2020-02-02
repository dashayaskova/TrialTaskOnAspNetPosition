namespace DbProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class State : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.delivery", "State", c => c.Int(nullable: false));
            AddColumn("dbo.delivery_store", "State", c => c.Int(nullable: false));
            AddColumn("dbo.store", "State", c => c.Int(nullable: false));
            AddColumn("dbo.item", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.item", "State");
            DropColumn("dbo.store", "State");
            DropColumn("dbo.delivery_store", "State");
            DropColumn("dbo.delivery", "State");
        }
    }
}
