using DndMate.WebApp.Dtos;
using System.Collections.Generic;

namespace DndMate.WebApp.ViewModels
{
    public class GetSpellViewModel
    {
        public SpellDto Spell { get; set; }
        public IEnumerable<GamespaceCharDto> Characters { get; set; }
    }
}