using DndMate.WebApp.Dtos;
using System.Collections.Generic;

namespace DndMate.WebApp.ViewModels
{
    public class SpellListViewModel
    {
        public GamespacePropsViewModel Gamespace { get; set; }
        public IEnumerable<SpellDto> Spells { get; set; }
        public IEnumerable<SpellDto> AssignedSpells { get; set; }

    }
}