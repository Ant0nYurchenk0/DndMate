using DndMate.WebApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace DndMate.WebApp.Models
{
    public class GamespaceChar
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CharacterId { get; set; }
        public Character Character { get; set; }
        public int GamespaceId { get; set; }
        public Gamespace Gamespace { get; set; }

        public int Platinum { get; set; }
        public int Gold {get; set; }
        public int Silver { get; set; }
        public int Copper { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int ProfBonus { get; set; }
        public bool Inspiration { get; set; }
        public bool StrengthSave { get; set; }
        public bool DexteritySave { get; set; }
        public bool ConstitutionSave { get; set; }
        public bool IntelligenceSave { get; set; }
        public bool WisdomSave { get; set; }
        public bool CharismaSave { get; set; }
        public bool Athletics { get; set; }
        public bool Acrobatics { get; set; }
        public bool SleightOfHand { get; set; }
        public bool Stealth { get; set; }
        public bool Arcana { get; set; }
        public bool History { get; set; }
        public bool Nature { get; set; }
        public bool Religion { get; set; }
        public bool AnimalHandling { get; set; }
        public bool Insight { get; set; }
        public bool Medicine { get; set; }
        public bool Perception { get; set; }
        public bool Survival { get; set; }
        public bool Deception { get; set; }
        public bool Intimidation { get; set; }
        public bool Performance { get; set; }
        public bool Persuasion { get; set; }

        [Range(0, 20)]
        public int Level { get; set; }
        public CharacterClass CharacterClass { get; set; }
        public Race Race { get; set; }
        public int ArmorClass { get; set; }
        public int Speed { get; set; }
        public string HitDice { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int BonusHP { get; set; }
        public int Failures { get; set; }
        public int Successes { get; set; }
        public int Special { get; set; }
        public int SpecialUsed { get; set; }
        public int Level1 { get; set; }
        public int Level1Used { get; set; }
        public int Level2 { get; set; }
        public int Level2Used { get; set; }
        public int Level3 { get; set; }
        public int Level3Used { get; set; }
        public int Level4 { get; set; }
        public int Level4Used { get; set; }
        public int Level5 { get; set; }
        public int Level5Used { get; set; }
        public int Level6 { get; set; }
        public int Level6Used { get; set; }
        public int Level7 { get; set; }
        public int Level7Used { get; set; }
        public int Level8 { get; set; }
        public int Level8Used { get; set; }
        public int Level9 { get; set; }
        public int Level9Used { get; set; }

        public string Alignment { get; set; }
        public string Background { get; set; }
        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public string Proficiencies { get; set; }
        public string Features { get; set; }
    }
}