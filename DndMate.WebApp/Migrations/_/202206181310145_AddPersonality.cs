namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonality : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GamespaceChars", "Alignment", c => c.String());
            AddColumn("dbo.GamespaceChars", "Background", c => c.String());
            AddColumn("dbo.GamespaceChars", "PersonalityTraits", c => c.String());
            AddColumn("dbo.GamespaceChars", "Ideals", c => c.String());
            AddColumn("dbo.GamespaceChars", "Bonds", c => c.String());
            AddColumn("dbo.GamespaceChars", "Flaws", c => c.String());
            AddColumn("dbo.GamespaceChars", "Proficiencies", c => c.String());
            AddColumn("dbo.GamespaceChars", "Features", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GamespaceChars", "Features");
            DropColumn("dbo.GamespaceChars", "Proficiencies");
            DropColumn("dbo.GamespaceChars", "Flaws");
            DropColumn("dbo.GamespaceChars", "Bonds");
            DropColumn("dbo.GamespaceChars", "Ideals");
            DropColumn("dbo.GamespaceChars", "PersonalityTraits");
            DropColumn("dbo.GamespaceChars", "Background");
            DropColumn("dbo.GamespaceChars", "Alignment");
        }
    }
}
