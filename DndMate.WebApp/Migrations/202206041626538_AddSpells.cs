namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpells : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GamespaceSpells",
                c => new
                    {
                        SpellId = c.Int(nullable: false),
                        GamespaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SpellId, t.GamespaceId })
                .ForeignKey("dbo.Gamespaces", t => t.GamespaceId, cascadeDelete: true)
                .ForeignKey("dbo.Spells", t => t.SpellId, cascadeDelete: true)
                .Index(t => t.SpellId)
                .Index(t => t.GamespaceId);
            
            CreateTable(
                "dbo.Spells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamespaceSpells", "SpellId", "dbo.Spells");
            DropForeignKey("dbo.GamespaceSpells", "GamespaceId", "dbo.Gamespaces");
            DropIndex("dbo.GamespaceSpells", new[] { "GamespaceId" });
            DropIndex("dbo.GamespaceSpells", new[] { "SpellId" });
            DropTable("dbo.Spells");
            DropTable("dbo.GamespaceSpells");
        }
    }
}
