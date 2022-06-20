using DndMate.WebApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.ViewModels
{
    public class ItemFormViewModel
    {
        public GamespacePropsViewModel Gamespace { get; set; }
        public ItemDto Item { get; set; }
    }
}