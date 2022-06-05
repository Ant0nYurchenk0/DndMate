using DndMate.WebApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Models
{
    public class GamespaceChar
    {

        public string CharacterId { get; set; }
        public Character Character { get; set; }
        public int GamespaceId { get; set; }
        public Gamespace Gamespace { get; set; }

        public CharacterClass CharacterClass { get; set; }
        public Role Role { get; set; }
        public int Level { get; set; }
    }
}