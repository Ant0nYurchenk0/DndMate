namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCharacterSpells1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GamespaceCharacterSpells", "SpellId", c => c.Int(nullable: false));
            CreateIndex("dbo.GamespaceCharacterSpells", "SpellId");
            AddForeignKey("dbo.GamespaceCharacterSpells", "SpellId", "dbo.GamespaceSpells", "Id", cascadeDelete: false); //changed to false
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamespaceCharacterSpells", "SpellId", "dbo.GamespaceSpells");
            DropIndex("dbo.GamespaceCharacterSpells", new[] { "SpellId" });
            DropColumn("dbo.GamespaceCharacterSpells", "SpellId");
        }
    }
}
