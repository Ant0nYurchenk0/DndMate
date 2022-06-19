namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRoleFromCharacter : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GamespaceChars", "CharacterClass", c => c.Int(nullable: false));
            DropColumn("dbo.GamespaceChars", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GamespaceChars", "Role", c => c.Int());
            AlterColumn("dbo.GamespaceChars", "CharacterClass", c => c.Int());
        }
    }
}
