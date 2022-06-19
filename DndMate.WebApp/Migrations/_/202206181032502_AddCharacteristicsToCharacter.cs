namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCharacteristicsToCharacter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GamespaceChars", "Race", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "ArmorClass", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Speed", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "HitDice", c => c.String());
            AddColumn("dbo.GamespaceChars", "MaxHP", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "CurrentHP", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Failures", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Successes", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Special", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "SpecialUsed", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level1", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level1Used", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level2", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level2Used", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level3", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level3Used", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level4", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level4Used", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level5", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level5Used", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level6", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level6Used", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level7", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level7Used", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level8", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level8Used", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level9", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Level9Used", c => c.Int(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Strength", c => c.Int(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Dexterity", c => c.Int(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Constitution", c => c.Int(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Intelligence", c => c.Int(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Wisdom", c => c.Int(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Charisma", c => c.Int(nullable: false));
            AlterColumn("dbo.GamespaceChars", "ProfBonus", c => c.Int(nullable: false));
            DropColumn("dbo.GamespaceChars", "PassiveWisdom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GamespaceChars", "PassiveWisdom", c => c.Int());
            AlterColumn("dbo.GamespaceChars", "ProfBonus", c => c.Int());
            AlterColumn("dbo.GamespaceChars", "Charisma", c => c.Int());
            AlterColumn("dbo.GamespaceChars", "Wisdom", c => c.Int());
            AlterColumn("dbo.GamespaceChars", "Intelligence", c => c.Int());
            AlterColumn("dbo.GamespaceChars", "Constitution", c => c.Int());
            AlterColumn("dbo.GamespaceChars", "Dexterity", c => c.Int());
            AlterColumn("dbo.GamespaceChars", "Strength", c => c.Int());
            DropColumn("dbo.GamespaceChars", "Level9Used");
            DropColumn("dbo.GamespaceChars", "Level9");
            DropColumn("dbo.GamespaceChars", "Level8Used");
            DropColumn("dbo.GamespaceChars", "Level8");
            DropColumn("dbo.GamespaceChars", "Level7Used");
            DropColumn("dbo.GamespaceChars", "Level7");
            DropColumn("dbo.GamespaceChars", "Level6Used");
            DropColumn("dbo.GamespaceChars", "Level6");
            DropColumn("dbo.GamespaceChars", "Level5Used");
            DropColumn("dbo.GamespaceChars", "Level5");
            DropColumn("dbo.GamespaceChars", "Level4Used");
            DropColumn("dbo.GamespaceChars", "Level4");
            DropColumn("dbo.GamespaceChars", "Level3Used");
            DropColumn("dbo.GamespaceChars", "Level3");
            DropColumn("dbo.GamespaceChars", "Level2Used");
            DropColumn("dbo.GamespaceChars", "Level2");
            DropColumn("dbo.GamespaceChars", "Level1Used");
            DropColumn("dbo.GamespaceChars", "Level1");
            DropColumn("dbo.GamespaceChars", "SpecialUsed");
            DropColumn("dbo.GamespaceChars", "Special");
            DropColumn("dbo.GamespaceChars", "Successes");
            DropColumn("dbo.GamespaceChars", "Failures");
            DropColumn("dbo.GamespaceChars", "CurrentHP");
            DropColumn("dbo.GamespaceChars", "MaxHP");
            DropColumn("dbo.GamespaceChars", "HitDice");
            DropColumn("dbo.GamespaceChars", "Speed");
            DropColumn("dbo.GamespaceChars", "ArmorClass");
            DropColumn("dbo.GamespaceChars", "Race");
        }
    }
}
