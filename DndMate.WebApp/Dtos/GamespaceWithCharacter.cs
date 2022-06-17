using DndMate.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Dtos
{
    public class GamespaceWithCharacter
    {
        public GamespaceDto Gamespace { get; set; }
        public GamespaceCharDto Character { get; set; }
    }
}