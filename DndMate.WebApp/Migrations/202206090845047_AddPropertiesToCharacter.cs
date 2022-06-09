namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToCharacter : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GamespaceChars", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.GamespaceChars", "CharacterClass", c => c.Int(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GamespaceChars", "Level", c => c.Int());
            AlterColumn("dbo.GamespaceChars", "CharacterClass", c => c.Int());
            AlterColumn("dbo.GamespaceChars", "Name", c => c.String());
        }
    }
}
