using DndMate.WebApp.Dtos;
using System.Collections.Generic;

namespace DndMate.WebApp.ViewModels
{
    public class CharacterListViewModel
    {
        public IEnumerable<GamespaceCharDto> Characters { get; set; }
        public GamespacePropsViewModel Gamespace { get; set; }
    }
}