namespace DndMate.WebApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int CharacterId { get; set; }
        public GamespaceChar Character { get; set; }
    }
}