namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Long(nullable: false, identity: true),
                        CardNumber = c.String(nullable: false),
                        CardHolderName = c.String(nullable: false),
                        ExpYear = c.Int(nullable: false),
                        ExpMonth = c.Byte(nullable: false),
                        CVV = c.Int(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        CardType = c.String(nullable: false),
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
                        ZipCode = c.String(nullable: false),
                        AddressId = c.Int(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CardId = c.Long(),
                        CustomerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.Cards", t => t.CardId)
                .Index(t => t.AddressId)
                .Index(t => t.CardId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
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
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompPercentage = c.Double(nullable: false),
                        VendorPercentage = c.Double(nullable: false),
                        TaxPercentage = c.Double(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CardId", "dbo.Cards");
            DropForeignKey("dbo.Orders", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Orders", new[] { "CardId" });
            DropIndex("dbo.Orders", new[] { "AddressId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropTable("dbo.Subscriptions");
            DropTable("dbo.Products");
            DropTable("dbo.Addresses");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.Cards");
        }
    }
}
