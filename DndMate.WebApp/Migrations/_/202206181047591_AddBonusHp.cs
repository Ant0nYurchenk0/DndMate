namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBonusHp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GamespaceChars", "BonusHP", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GamespaceChars", "BonusHP");
        }
    }
}
