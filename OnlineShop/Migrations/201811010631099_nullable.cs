namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Long(nullable: false, identity: true),
                        CardNumber = c.String(),
                        CardHolderName = c.String(),
                        ExpYear = c.Int(nullable: false),
                        ExpMonth = c.Byte(nullable: false),
                        CVV = c.Int(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        Status = c.Byte(nullable: false),
                        CardType = c.String(),
                        CustomerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CardId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Byte(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Long(nullable: false, identity: true),
                        OrderId = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Long(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        AddressId = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CardId = c.Long(),
                        CustomerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Cards", t => t.CardId)
                .Index(t => t.CardId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Long(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        ProductDescription = c.String(nullable: false, maxLength: 200),
                        CategoryId = c.Byte(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitInStock = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CardId", "dbo.Cards");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Orders", new[] { "CardId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.Cards");
        }
    }
}
