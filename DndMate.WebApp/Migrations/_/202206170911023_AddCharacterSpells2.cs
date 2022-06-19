namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCharacterSpells2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GamespaceCharacterSpells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        SpellId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GamespaceChars", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Spells", t => t.SpellId, cascadeDelete: false)
                .Index(t => t.CharacterId)
                .Index(t => t.SpellId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamespaceCharacterSpells", "SpellId", "dbo.Spells");
            DropForeignKey("dbo.GamespaceCharacterSpells", "CharacterId", "dbo.GamespaceChars");
            DropIndex("dbo.GamespaceCharacterSpells", new[] { "SpellId" });
            DropIndex("dbo.GamespaceCharacterSpells", new[] { "CharacterId" });
            DropTable("dbo.GamespaceCharacterSpells");
        }
    }
}
