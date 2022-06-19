using System.ComponentModel.DataAnnotations;

namespace DndMate.WebApp.Dtos
{
    public class NoteDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        public int CharacterId { get; set; }

    }
}