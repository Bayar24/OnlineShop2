namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.Cards", "CardNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Cards", "CardHolderName", c => c.String(nullable: false));
            AlterColumn("dbo.Cards", "CardType", c => c.String(nullable: false));
            DropColumn("dbo.Cards", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cards", "Status", c => c.Byte(nullable: false));
            AlterColumn("dbo.Cards", "CardType", c => c.String());
            AlterColumn("dbo.Cards", "CardHolderName", c => c.String());
            AlterColumn("dbo.Cards", "CardNumber", c => c.String());
            DropColumn("dbo.Orders", "ZipCode");
        }
    }
}
