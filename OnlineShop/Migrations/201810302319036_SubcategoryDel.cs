namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubcategoryDel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Category_CategoryId", c => c.Byte());
            CreateIndex("dbo.Products", "Category_CategoryId");
            AddForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories", "CategoryId");
            DropColumn("dbo.Products", "SubCategoryId");
            DropTable("dbo.SubCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        SubCategoryName = c.String(nullable: false, maxLength: 100),
                        CategoryId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategoryId);
            
            AddColumn("dbo.Products", "SubCategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropColumn("dbo.Products", "Category_CategoryId");
            DropColumn("dbo.Products", "CategoryId");
            CreateIndex("dbo.SubCategories", "CategoryId");
            CreateIndex("dbo.Products", "SubCategoryId");
            AddForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories", "SubCategoryId", cascadeDelete: true);
            AddForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
    }
}
