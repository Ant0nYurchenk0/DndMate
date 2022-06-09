using DndMate.WebApp.Dtos;
using DndMate.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.ViewModels
{
    public class SpellListViewModel
    {
        public GamespacePropsViewModel Gamespace { get; set; }
        public IEnumerable<SpellDto> Spells { get; set; }
    }
}