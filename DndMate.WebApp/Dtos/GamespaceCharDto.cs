using DndMate.WebApp.Enums;
using DndMate.WebApp.Models;
using DndMate.WebApp.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Dtos
{
    public class GamespaceCharDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CharacterId { get; set; }
        public int GamespaceId { get; set; }
        public CharacterClass CharacterClass { get; set; }
        [Required]
        [Range(0, 20)]
        public int? Level { get; set; }
    }
}