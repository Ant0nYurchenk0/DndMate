using DndMate.WebApp.Dtos;
using System.Collections.Generic;

namespace DndMate.WebApp.ViewModels
{
    public class GamespaceListViewModel
    {
        public GamespaceListViewModel()
        {
            Gamespaces = new List<GamespaceWithCharacter>();
        }
        public List<GamespaceWithCharacter> Gamespaces { get; set; }
    }
}