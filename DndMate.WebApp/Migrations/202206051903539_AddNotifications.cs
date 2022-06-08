namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotifications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GamespaceId = c.Int(nullable: false),
                        UserEmail = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gamespaces", t => t.GamespaceId, cascadeDelete: true)
                .Index(t => t.GamespaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "GamespaceId", "dbo.Gamespaces");
            DropIndex("dbo.Notifications", new[] { "GamespaceId" });
            DropTable("dbo.Notifications");
        }
    }
}
