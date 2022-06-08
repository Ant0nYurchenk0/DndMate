using DndMate.WebApp.Enums;
using DndMate.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Dtos
{
    public class GamespaceCharDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CharacterId { get; set; }
        public int GamespaceId { get; set; }
        public CharacterClass? CharacterClass { get; set; }
        public Role? Role { get; set; }
        public int? Level { get; set; }
    }
}