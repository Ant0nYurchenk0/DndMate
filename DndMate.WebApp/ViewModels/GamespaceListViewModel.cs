using DndMate.WebApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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