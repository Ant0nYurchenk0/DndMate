namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "CharacterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notes", "CharacterId");
            AddForeignKey("dbo.Notes", "CharacterId", "dbo.GamespaceChars", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "CharacterId", "dbo.GamespaceChars");
            DropIndex("dbo.Notes", new[] { "CharacterId" });
            DropColumn("dbo.Notes", "CharacterId");
        }
    }
}
