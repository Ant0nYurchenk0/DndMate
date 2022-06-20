namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GamespaceCharacterItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GamespaceChars", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: false)//changed to false
                .Index(t => t.CharacterId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ItemType = c.Int(nullable: false),
                        Rarity = c.Int(nullable: false),
                        Properties = c.String(),
                        Damage = c.String(),
                        Description = c.String(),
                        GamespaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gamespaces", t => t.GamespaceId, cascadeDelete: true)
                .Index(t => t.GamespaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamespaceCharacterItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "GamespaceId", "dbo.Gamespaces");
            DropForeignKey("dbo.GamespaceCharacterItems", "CharacterId", "dbo.GamespaceChars");
            DropIndex("dbo.Items", new[] { "GamespaceId" });
            DropIndex("dbo.GamespaceCharacterItems", new[] { "ItemId" });
            DropIndex("dbo.GamespaceCharacterItems", new[] { "CharacterId" });
            DropTable("dbo.Items");
            DropTable("dbo.GamespaceCharacterItems");
        }
    }
}
