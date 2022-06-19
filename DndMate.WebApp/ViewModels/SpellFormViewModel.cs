using DndMate.WebApp.Dtos;

namespace DndMate.WebApp.ViewModels
{
    public class SpellFormViewModel
    {
        public GamespacePropsViewModel Gamespace { get; set; }
        public SpellDto Spell { get; set; }
    }
}