namespace FoodDeliverySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CompanyTypeID = c.Int(nullable: false),
                        Logo = c.Binary(),
                        CompanyCostTypeID = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CompanyCostTypes", t => t.CompanyCostTypeID, cascadeDelete: false)
                .ForeignKey("dbo.CompanyTypes", t => t.CompanyTypeID, cascadeDelete: false)
                .Index(t => t.CompanyTypeID)
                .Index(t => t.CompanyCostTypeID);
            
            CreateTable(
                "dbo.CompanyCostTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CostType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CompanyTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyTypeName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        CompanyID = c.Int(nullable: false),
                        RaitingID = c.Int(nullable: false),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                        state = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: false)
                .ForeignKey("dbo.Raitings", t => t.RaitingID, cascadeDelete: false)
                .Index(t => t.CompanyID)
                .Index(t => t.RaitingID);
            
            CreateTable(
                "dbo.Raitings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        score = c.Int(nullable: false),
                        Comment = c.String(),
                        CompanyID = c.Int(nullable: false),
                        CommentTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CommentTypes", t => t.CommentTypeID, cascadeDelete: false)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: false)
                .Index(t => t.CompanyID)
                .Index(t => t.CommentTypeID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Name = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductCategoryID = c.Int(nullable: false),
                        CookingTime = c.Int(nullable: false),
                        GeneralProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: false)
                .ForeignKey("dbo.GeneralProducts", t => t.GeneralProductID, cascadeDelete: false)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryID, cascadeDelete: false)
                .Index(t => t.CompanyID)
                .Index(t => t.ProductCategoryID)
                .Index(t => t.GeneralProductID);
            
            CreateTable(
                "dbo.GeneralProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GeneralDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.RoleId, cascadeDelete: false)
                .ForeignKey("dbo.IdentityUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserRoles", "RoleId", "dbo.IdentityRoles");
            DropForeignKey("dbo.IdentityUserLogins", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserClaims", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Raitings", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Products", "ProductCategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.Products", "GeneralProductID", "dbo.GeneralProducts");
            DropForeignKey("dbo.Products", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Orders", "RaitingID", "dbo.Raitings");
            DropForeignKey("dbo.Raitings", "CommentTypeID", "dbo.CommentTypes");
            DropForeignKey("dbo.Orders", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Companies", "CompanyTypeID", "dbo.CompanyTypes");
            DropForeignKey("dbo.Companies", "CompanyCostTypeID", "dbo.CompanyCostTypes");
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "RoleId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "User_Id" });
            DropIndex("dbo.Products", new[] { "GeneralProductID" });
            DropIndex("dbo.Products", new[] { "ProductCategoryID" });
            DropIndex("dbo.Products", new[] { "CompanyID" });
            DropIndex("dbo.Raitings", new[] { "CommentTypeID" });
            DropIndex("dbo.Raitings", new[] { "CompanyID" });
            DropIndex("dbo.Orders", new[] { "RaitingID" });
            DropIndex("dbo.Orders", new[] { "CompanyID" });
            DropIndex("dbo.Companies", new[] { "CompanyCostTypeID" });
            DropIndex("dbo.Companies", new[] { "CompanyTypeID" });
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.IdentityUsers");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.GeneralProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Raitings");
            DropTable("dbo.Orders");
            DropTable("dbo.CompanyTypes");
            DropTable("dbo.CompanyCostTypes");
            DropTable("dbo.Companies");
            DropTable("dbo.CommentTypes");
        }
    }
}
