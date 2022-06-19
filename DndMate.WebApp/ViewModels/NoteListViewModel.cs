using DndMate.WebApp.Dtos;
using System.Collections.Generic;

namespace DndMate.WebApp.ViewModels
{
    public class NoteListViewModel
    {
        public IEnumerable<NoteDto> MyNotes { get; set; }
        public IEnumerable<NoteDto> MasterNotes { get; set; }
        public GamespacePropsViewModel Gamespace { get; set; }

    }
}