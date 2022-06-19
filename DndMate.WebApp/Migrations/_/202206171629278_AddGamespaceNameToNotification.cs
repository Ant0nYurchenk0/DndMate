namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGamespaceNameToNotification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "GamespaceName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "GamespaceName");
        }
    }
}
