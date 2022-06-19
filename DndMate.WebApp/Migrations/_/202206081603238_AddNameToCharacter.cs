namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToCharacter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GamespaceChars", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GamespaceChars", "Name");
        }
    }
}
