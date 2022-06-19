using System.ComponentModel.DataAnnotations;

namespace DndMate.WebApp.Dtos
{
    public class GamespaceDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}