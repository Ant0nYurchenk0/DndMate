namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "Message", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifications", "Message", c => c.String());
        }
    }
}
