using DndMate.WebApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.ViewModels
{
    public class GamespaceFormViewModel
    {
        public GamespacePropsViewModel GamespaceProps { get; set; }
        public GamespaceDto Gamespace { get; set; }
    }
}