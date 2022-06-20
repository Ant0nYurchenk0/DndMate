namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoney : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GamespaceChars", "Platinum", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Gold", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Silver", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Copper", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GamespaceChars", "Copper");
            DropColumn("dbo.GamespaceChars", "Silver");
            DropColumn("dbo.GamespaceChars", "Gold");
            DropColumn("dbo.GamespaceChars", "Platinum");
        }
    }
}
