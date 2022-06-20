using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Models
{
    public class GamespaceCharacterItems
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public GamespaceChar Character { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}