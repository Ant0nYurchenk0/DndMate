namespace DndMate.WebApp.Models
{
    public class GamespaceCharacterSpell
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public GamespaceChar Character { get; set; }
        public int SpellId { get; set; }
        public Spell Spell { get; set; }
        public bool IsActive { get; set; }
    }
}