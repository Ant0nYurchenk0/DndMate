namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatsToCharacter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GamespaceChars", "Strength", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Dexterity", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Constitution", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Intelligence", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Wisdom", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Charisma", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "ProfBonus", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "PassiveWisdom", c => c.Int(nullable: false));
            AddColumn("dbo.GamespaceChars", "Inspiration", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "StrengthSave", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "DexteritySave", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "ConstitutionSave", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "IntelligenceSave", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "WisdomSave", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "CharismaSave", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Athletics", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Acrobatics", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "SleightOfHand", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Stealth", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Arcana", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "History", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Nature", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Religion", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "AnimalHandling", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Insight", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Medicine", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Perception", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Survival", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Deception", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Intimidation", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Performance", c => c.Boolean(nullable: false));
            AddColumn("dbo.GamespaceChars", "Persuasion", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GamespaceChars", "Persuasion");
            DropColumn("dbo.GamespaceChars", "Performance");
            DropColumn("dbo.GamespaceChars", "Intimidation");
            DropColumn("dbo.GamespaceChars", "Deception");
            DropColumn("dbo.GamespaceChars", "Survival");
            DropColumn("dbo.GamespaceChars", "Perception");
            DropColumn("dbo.GamespaceChars", "Medicine");
            DropColumn("dbo.GamespaceChars", "Insight");
            DropColumn("dbo.GamespaceChars", "AnimalHandling");
            DropColumn("dbo.GamespaceChars", "Religion");
            DropColumn("dbo.GamespaceChars", "Nature");
            DropColumn("dbo.GamespaceChars", "History");
            DropColumn("dbo.GamespaceChars", "Arcana");
            DropColumn("dbo.GamespaceChars", "Stealth");
            DropColumn("dbo.GamespaceChars", "SleightOfHand");
            DropColumn("dbo.GamespaceChars", "Acrobatics");
            DropColumn("dbo.GamespaceChars", "Athletics");
            DropColumn("dbo.GamespaceChars", "CharismaSave");
            DropColumn("dbo.GamespaceChars", "WisdomSave");
            DropColumn("dbo.GamespaceChars", "IntelligenceSave");
            DropColumn("dbo.GamespaceChars", "ConstitutionSave");
            DropColumn("dbo.GamespaceChars", "DexteritySave");
            DropColumn("dbo.GamespaceChars", "StrengthSave");
            DropColumn("dbo.GamespaceChars", "Inspiration");
            DropColumn("dbo.GamespaceChars", "PassiveWisdom");
            DropColumn("dbo.GamespaceChars", "ProfBonus");
            DropColumn("dbo.GamespaceChars", "Charisma");
            DropColumn("dbo.GamespaceChars", "Wisdom");
            DropColumn("dbo.GamespaceChars", "Intelligence");
            DropColumn("dbo.GamespaceChars", "Constitution");
            DropColumn("dbo.GamespaceChars", "Dexterity");
            DropColumn("dbo.GamespaceChars", "Strength");
        }
    }
}
