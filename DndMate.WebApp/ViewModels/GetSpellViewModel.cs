using DndMate.WebApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.ViewModels
{
    public class GetSpellViewModel
    {
        public SpellDto Spell { get; set; }
        public IEnumerable<GamespaceCharDto> Characters { get; set; }
    }
}