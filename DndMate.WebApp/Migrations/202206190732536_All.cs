namespace DndMate.WebApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class All : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GamespaceChars",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    CharacterId = c.String(maxLength: 128),
                    GamespaceId = c.Int(nullable: false),
                    Strength = c.Int(nullable: false),
                    Dexterity = c.Int(nullable: false),
                    Constitution = c.Int(nullable: false),
                    Intelligence = c.Int(nullable: false),
                    Wisdom = c.Int(nullable: false),
                    Charisma = c.Int(nullable: false),
                    ProfBonus = c.Int(nullable: false),
                    Inspiration = c.Boolean(nullable: false),
                    StrengthSave = c.Boolean(nullable: false),
                    DexteritySave = c.Boolean(nullable: false),
                    ConstitutionSave = c.Boolean(nullable: false),
                    IntelligenceSave = c.Boolean(nullable: false),
                    WisdomSave = c.Boolean(nullable: false),
                    CharismaSave = c.Boolean(nullable: false),
                    Athletics = c.Boolean(nullable: false),
                    Acrobatics = c.Boolean(nullable: false),
                    SleightOfHand = c.Boolean(nullable: false),
                    Stealth = c.Boolean(nullable: false),
                    Arcana = c.Boolean(nullable: false),
                    History = c.Boolean(nullable: false),
                    Nature = c.Boolean(nullable: false),
                    Religion = c.Boolean(nullable: false),
                    AnimalHandling = c.Boolean(nullable: false),
                    Insight = c.Boolean(nullable: false),
                    Medicine = c.Boolean(nullable: false),
                    Perception = c.Boolean(nullable: false),
                    Survival = c.Boolean(nullable: false),
                    Deception = c.Boolean(nullable: false),
                    Intimidation = c.Boolean(nullable: false),
                    Performance = c.Boolean(nullable: false),
                    Persuasion = c.Boolean(nullable: false),
                    Level = c.Int(nullable: false),
                    CharacterClass = c.Int(nullable: false),
                    Race = c.Int(nullable: false),
                    ArmorClass = c.Int(nullable: false),
                    Speed = c.Int(nullable: false),
                    HitDice = c.String(),
                    MaxHP = c.Int(nullable: false),
                    CurrentHP = c.Int(nullable: false),
                    BonusHP = c.Int(nullable: false),
                    Failures = c.Int(nullable: false),
                    Successes = c.Int(nullable: false),
                    Special = c.Int(nullable: false),
                    SpecialUsed = c.Int(nullable: false),
                    Level1 = c.Int(nullable: false),
                    Level1Used = c.Int(nullable: false),
                    Level2 = c.Int(nullable: false),
                    Level2Used = c.Int(nullable: false),
                    Level3 = c.Int(nullable: false),
                    Level3Used = c.Int(nullable: false),
                    Level4 = c.Int(nullable: false),
                    Level4Used = c.Int(nullable: false),
                    Level5 = c.Int(nullable: false),
                    Level5Used = c.Int(nullable: false),
                    Level6 = c.Int(nullable: false),
                    Level6Used = c.Int(nullable: false),
                    Level7 = c.Int(nullable: false),
                    Level7Used = c.Int(nullable: false),
                    Level8 = c.Int(nullable: false),
                    Level8Used = c.Int(nullable: false),
                    Level9 = c.Int(nullable: false),
                    Level9Used = c.Int(nullable: false),
                    Alignment = c.String(),
                    Background = c.String(),
                    PersonalityTraits = c.String(),
                    Ideals = c.String(),
                    Bonds = c.String(),
                    Flaws = c.String(),
                    Proficiencies = c.String(),
                    Features = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CharacterId)
                .ForeignKey("dbo.Gamespaces", t => t.GamespaceId, cascadeDelete: true)
                .Index(t => t.CharacterId)
                .Index(t => t.GamespaceId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Gamespaces",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.GamespaceCharacterSpells",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CharacterId = c.Int(nullable: false),
                    SpellId = c.Int(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GamespaceChars", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Spells", t => t.SpellId, cascadeDelete: false)// changed to false
                .Index(t => t.CharacterId)
                .Index(t => t.SpellId);

            CreateTable(
                "dbo.Spells",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Level = c.Int(nullable: false),
                    CastingTime = c.String(),
                    Range = c.String(),
                    Components = c.String(),
                    Duration = c.String(),
                    Description = c.String(),
                    GamespaceId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gamespaces", t => t.GamespaceId, cascadeDelete: true)
                .Index(t => t.GamespaceId);

            CreateTable(
                "dbo.Notes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Content = c.String(),
                    CharacterId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GamespaceChars", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);

            CreateTable(
                "dbo.Notifications",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    GamespaceId = c.Int(nullable: false),
                    UserEmail = c.String(),
                    Message = c.String(maxLength: 100),
                    GamespaceName = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gamespaces", t => t.GamespaceId, cascadeDelete: true)
                .Index(t => t.GamespaceId);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Notifications", "GamespaceId", "dbo.Gamespaces");
            DropForeignKey("dbo.Notes", "CharacterId", "dbo.GamespaceChars");
            DropForeignKey("dbo.GamespaceCharacterSpells", "SpellId", "dbo.Spells");
            DropForeignKey("dbo.Spells", "GamespaceId", "dbo.Gamespaces");
            DropForeignKey("dbo.GamespaceCharacterSpells", "CharacterId", "dbo.GamespaceChars");
            DropForeignKey("dbo.GamespaceChars", "GamespaceId", "dbo.Gamespaces");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.GamespaceChars", "CharacterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Notifications", new[] { "GamespaceId" });
            DropIndex("dbo.Notes", new[] { "CharacterId" });
            DropIndex("dbo.Spells", new[] { "GamespaceId" });
            DropIndex("dbo.GamespaceCharacterSpells", new[] { "SpellId" });
            DropIndex("dbo.GamespaceCharacterSpells", new[] { "CharacterId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.GamespaceChars", new[] { "GamespaceId" });
            DropIndex("dbo.GamespaceChars", new[] { "CharacterId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Notifications");
            DropTable("dbo.Notes");
            DropTable("dbo.Spells");
            DropTable("dbo.GamespaceCharacterSpells");
            DropTable("dbo.Gamespaces");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.GamespaceChars");
        }
    }
}
