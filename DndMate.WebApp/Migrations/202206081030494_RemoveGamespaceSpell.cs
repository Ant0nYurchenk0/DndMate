namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGamespaceSpell : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GamespaceSpells", "GamespaceId", "dbo.Gamespaces");
            DropForeignKey("dbo.GamespaceSpells", "SpellId", "dbo.Spells");
            DropIndex("dbo.GamespaceSpells", new[] { "GamespaceId" });
            DropIndex("dbo.GamespaceSpells", new[] { "SpellId" });
            AddColumn("dbo.Spells", "GamespaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Spells", "GamespaceId");
            AddForeignKey("dbo.Spells", "GamespaceId", "dbo.Gamespaces", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GamespaceSpells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GamespaceId = c.Int(nullable: false),
                        SpellId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Spells", "GamespaceId", "dbo.Gamespaces");
            DropIndex("dbo.Spells", new[] { "GamespaceId" });
            DropColumn("dbo.Spells", "GamespaceId");
            CreateIndex("dbo.GamespaceSpells", "SpellId");
            CreateIndex("dbo.GamespaceSpells", "GamespaceId");
            AddForeignKey("dbo.GamespaceSpells", "SpellId", "dbo.Spells", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GamespaceSpells", "GamespaceId", "dbo.Gamespaces", "Id", cascadeDelete: true);
        }
    }
}
