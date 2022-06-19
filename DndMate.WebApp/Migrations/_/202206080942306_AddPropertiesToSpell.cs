namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToSpell : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Spells", "FullName", c => c.String());
            AddColumn("dbo.Spells", "CastingTime", c => c.String());
            AddColumn("dbo.Spells", "Range", c => c.String());
            AddColumn("dbo.Spells", "Components", c => c.String());
            AddColumn("dbo.Spells", "Duration", c => c.String());
            AddColumn("dbo.Spells", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Spells", "Description");
            DropColumn("dbo.Spells", "Duration");
            DropColumn("dbo.Spells", "Components");
            DropColumn("dbo.Spells", "Range");
            DropColumn("dbo.Spells", "CastingTime");
            DropColumn("dbo.Spells", "FullName");
        }
    }
}
