namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveImageAndFullnameFromSpell : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Spells", "FullName");
            DropColumn("dbo.Spells", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Spells", "Image", c => c.String());
            AddColumn("dbo.Spells", "FullName", c => c.String());
        }
    }
}
