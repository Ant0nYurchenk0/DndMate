using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Dtos
{
    public class SpellDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        [Range(0, 20)]
        public int Level { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public int GamespaceId { get; set; }
    }
}