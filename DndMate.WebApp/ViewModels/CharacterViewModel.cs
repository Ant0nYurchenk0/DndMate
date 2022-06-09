using DndMate.WebApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.ViewModels
{
    public class CharacterViewModel
    {
        public GamespacePropsViewModel Gamespace { get; set; }
        public GamespaceCharDto Character { get; set; }
    }
}