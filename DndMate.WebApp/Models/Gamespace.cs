using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DndMate.WebApp.Models
{
    public class Gamespace
    {
        public Gamespace()
        {
            GamespaceCharacters = new List<GamespaceChar>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GamespaceChar> GamespaceCharacters { get; set; }
    }
}