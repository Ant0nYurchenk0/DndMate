using DndMate.WebApp.Dtos;

namespace DndMate.WebApp.ViewModels
{
    public class NoteFormViewModel
    {
        public GamespacePropsViewModel Gamespace { get; set; }
        public NoteDto Note { get; set; }
    }
}