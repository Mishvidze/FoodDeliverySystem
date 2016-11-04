namespace FoodDeliverySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddedpriceHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TotalCost2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TotalCost2");
        }
    }
}
