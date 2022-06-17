using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Models
{
    public class Spell
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0, 9)]
        public int Level { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public int GamespaceId { get; set; }
        public Gamespace Gamespace { get; set; }
    }

}