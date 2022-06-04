using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Models
{

    public class Spell
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Level { get; set; }
        public List<GamespaceSpell> Spells { get; set; }
    }

}