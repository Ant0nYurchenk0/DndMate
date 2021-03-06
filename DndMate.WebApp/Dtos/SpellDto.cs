using System.ComponentModel.DataAnnotations;

namespace DndMate.WebApp.Dtos
{
    public class SpellDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0, 9)]
        public int Level { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public int GamespaceId { get; set; }
    }
}