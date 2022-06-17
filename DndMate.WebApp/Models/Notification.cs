using DndMate.WebApp.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int GamespaceId { get; set; }
        public Gamespace Gamespace { get; set; }
        [EmailExists]
        public string UserEmail { get; set; }
        [MaxLength(100)]
        public string Message { get; set; }
        public string GamespaceName { get; set; }
    }
}