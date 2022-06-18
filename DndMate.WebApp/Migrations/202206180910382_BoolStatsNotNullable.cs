namespace DndMate.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoolStatsNotNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GamespaceChars", "Inspiration", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "StrengthSave", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "DexteritySave", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "ConstitutionSave", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "IntelligenceSave", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "WisdomSave", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "CharismaSave", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Athletics", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Acrobatics", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "SleightOfHand", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Stealth", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Arcana", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "History", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Nature", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Religion", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "AnimalHandling", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Insight", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Medicine", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Perception", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Survival", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Deception", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Intimidation", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Performance", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GamespaceChars", "Persuasion", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GamespaceChars", "Persuasion", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Performance", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Intimidation", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Deception", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Survival", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Perception", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Medicine", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Insight", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "AnimalHandling", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Religion", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Nature", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "History", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Arcana", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Stealth", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "SleightOfHand", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Acrobatics", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Athletics", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "CharismaSave", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "WisdomSave", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "IntelligenceSave", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "ConstitutionSave", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "DexteritySave", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "StrengthSave", c => c.Boolean());
            AlterColumn("dbo.GamespaceChars", "Inspiration", c => c.Boolean());
        }
    }
}
