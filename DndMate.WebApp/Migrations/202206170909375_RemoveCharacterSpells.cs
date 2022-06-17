namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCharacterSpells : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GamespaceCharacterSpells", "CharacterId", "dbo.GamespaceChars");
            DropForeignKey("dbo.GamespaceCharacterSpells", "SpellId", "dbo.Spells");
            DropIndex("dbo.GamespaceCharacterSpells", new[] { "CharacterId" });
            DropIndex("dbo.GamespaceCharacterSpells", new[] { "SpellId" });
            //DropTable("dbo.GamespaceCharacterSpells");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.GamespaceCharacterSpells", "SpellId");
            CreateIndex("dbo.GamespaceCharacterSpells", "CharacterId");
            AddForeignKey("dbo.GamespaceCharacterSpells", "SpellId", "dbo.Spells", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GamespaceCharacterSpells", "CharacterId", "dbo.GamespaceChars", "Id", cascadeDelete: true);
        }
    }
}
