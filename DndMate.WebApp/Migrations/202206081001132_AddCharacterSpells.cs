namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCharacterSpells : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GamespaceChars", "CharacterId", "dbo.AspNetUsers");
            DropIndex("dbo.GamespaceChars", new[] { "CharacterId" });
            DropPrimaryKey("dbo.GamespaceChars");
            DropPrimaryKey("dbo.GamespaceSpells");
            CreateTable(
                "dbo.GamespaceCharacterSpells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GamespaceChars", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);
            
            AddColumn("dbo.GamespaceChars", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.GamespaceSpells", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.GamespaceChars", "CharacterId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.GamespaceChars", "Id");
            AddPrimaryKey("dbo.GamespaceSpells", "Id");
            CreateIndex("dbo.GamespaceChars", "CharacterId");
            AddForeignKey("dbo.GamespaceChars", "CharacterId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamespaceChars", "CharacterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.GamespaceCharacterSpells", "CharacterId", "dbo.GamespaceChars");
            DropIndex("dbo.GamespaceChars", new[] { "CharacterId" });
            DropIndex("dbo.GamespaceCharacterSpells", new[] { "CharacterId" });
            DropPrimaryKey("dbo.GamespaceSpells");
            DropPrimaryKey("dbo.GamespaceChars");
            AlterColumn("dbo.GamespaceChars", "CharacterId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.GamespaceSpells", "Id");
            DropColumn("dbo.GamespaceChars", "Id");
            DropTable("dbo.GamespaceCharacterSpells");
            AddPrimaryKey("dbo.GamespaceSpells", new[] { "SpellId", "GamespaceId" });
            AddPrimaryKey("dbo.GamespaceChars", new[] { "CharacterId", "GamespaceId" });
            CreateIndex("dbo.GamespaceChars", "CharacterId");
            AddForeignKey("dbo.GamespaceChars", "CharacterId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
