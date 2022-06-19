namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GamespaceChars", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GamespaceChars", "Id", c => c.Int(nullable: false));
        }
    }
}
