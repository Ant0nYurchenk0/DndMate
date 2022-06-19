using DndMate.WebApp.Dtos;

namespace DndMate.WebApp.ViewModels
{
    public class CharacterViewModel
    {
        public GamespacePropsViewModel Gamespace { get; set; }
        public GamespaceCharDto Character { get; set; }
    }
}