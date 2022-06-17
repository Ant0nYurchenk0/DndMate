namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GamespaceRemoveImageAddDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gamespaces", "Description", c => c.String());
            DropColumn("dbo.Gamespaces", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gamespaces", "Image", c => c.String(nullable: false));
            DropColumn("dbo.Gamespaces", "Description");
        }
    }
}
