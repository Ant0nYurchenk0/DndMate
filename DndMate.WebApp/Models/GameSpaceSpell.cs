using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Models
{

    public class GamespaceSpell
    {

        public int GamespaceId { get; set; }
        public int SpellId { get; set; }
        public Gamespace Gamespace { get; set; }
        public Spell Spell { get; set; }

    }
}