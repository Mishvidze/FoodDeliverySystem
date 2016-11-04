namespace FoodDeliverySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedorderedproducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderedProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: true),
                        ProductCode = c.String(),
                        ProductQuantity = c.Int(nullable: true),
                        Price = c.Decimal(nullable: true, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: false)
                .Index(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedProducts", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderedProducts", new[] { "OrderID" });
            DropTable("dbo.OrderedProducts");
        }
    }
}
