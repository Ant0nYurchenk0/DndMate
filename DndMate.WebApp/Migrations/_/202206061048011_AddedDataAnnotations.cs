namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GamespaceChars", "CharacterClass", c => c.Int());
            AlterColumn("dbo.GamespaceChars", "Role", c => c.Int());
            AlterColumn("dbo.GamespaceChars", "Level", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GamespaceChars", "Level", c => c.Int(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Role", c => c.Int(nullable: false));
            AlterColumn("dbo.GamespaceChars", "CharacterClass", c => c.Int(nullable: false));
        }
    }
}
