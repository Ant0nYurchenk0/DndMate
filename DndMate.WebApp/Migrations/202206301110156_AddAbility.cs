namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAbility : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GamespaceChars", "Ability", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GamespaceChars", "Ability");
        }
    }
}
