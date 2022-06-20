using DndMate.WebApp.Dtos;
using DndMate.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.ViewModels
{
    public class ItemListViewModel
    {
        public GamespacePropsViewModel Gamespace { get; set; }
        public IEnumerable<GamespaceCharacterItems> MyItems { get; set; }
        public IEnumerable<ItemDto> AllItems { get; set; }
    }
}