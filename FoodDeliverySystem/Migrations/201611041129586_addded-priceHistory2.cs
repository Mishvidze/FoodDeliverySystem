namespace FoodDeliverySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddedpriceHistory2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductPriceHistories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: true),
                        Price = c.Decimal(nullable: true, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: true),
                        Company_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.Company_ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: false)
                .Index(t => t.ProductID)
                .Index(t => t.Company_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPriceHistories", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductPriceHistories", "Company_ID", "dbo.Companies");
            DropIndex("dbo.ProductPriceHistories", new[] { "Company_ID" });
            DropIndex("dbo.ProductPriceHistories", new[] { "ProductID" });
            DropTable("dbo.ProductPriceHistories");
        }
    }
}
