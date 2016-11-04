namespace FoodDeliverySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforeignkeygp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderedProducts", "GeneralProductID", c => c.Int(nullable: false));
            AddColumn("dbo.OrderedProducts", "Company_ID", c => c.Int());
            CreateIndex("dbo.OrderedProducts", "GeneralProductID");
            CreateIndex("dbo.OrderedProducts", "Company_ID");
            AddForeignKey("dbo.OrderedProducts", "Company_ID", "dbo.Companies", "ID");
            AddForeignKey("dbo.OrderedProducts", "GeneralProductID", "dbo.GeneralProducts", "ID", cascadeDelete: false);
            DropColumn("dbo.OrderedProducts", "ProductCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderedProducts", "ProductCode", c => c.String());
            DropForeignKey("dbo.OrderedProducts", "GeneralProductID", "dbo.GeneralProducts");
            DropForeignKey("dbo.OrderedProducts", "Company_ID", "dbo.Companies");
            DropIndex("dbo.OrderedProducts", new[] { "Company_ID" });
            DropIndex("dbo.OrderedProducts", new[] { "GeneralProductID" });
            DropColumn("dbo.OrderedProducts", "Company_ID");
            DropColumn("dbo.OrderedProducts", "GeneralProductID");
        }
    }
}
