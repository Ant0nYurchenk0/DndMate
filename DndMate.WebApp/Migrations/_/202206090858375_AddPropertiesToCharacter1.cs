namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToCharacter1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GamespaceChars", "CharacterClass", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GamespaceChars", "CharacterClass", c => c.Int(nullable: false));
        }
    }
}
