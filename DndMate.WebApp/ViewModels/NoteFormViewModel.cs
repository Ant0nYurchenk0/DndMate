using DndMate.WebApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.ViewModels
{
    public class NoteFormViewModel
    {
        public GamespacePropsViewModel Gamespace { get; set; }
        public NoteDto Note{ get; set; }
    }
}