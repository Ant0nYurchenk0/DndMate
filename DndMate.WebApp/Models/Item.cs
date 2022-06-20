using DndMate.WebApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType ItemType { get; set; }
        public Rarity Rarity { get; set; }
        public string Properties { get; set; }
        public string Damage { get; set; }
        public string Description { get; set; }
        public Gamespace Gamespace { get; set; }
        public int GamespaceId { get; set; }
    }
}