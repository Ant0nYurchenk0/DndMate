using DndMate.WebApp.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Dtos
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public int GamespaceId { get; set; }
        [EmailExists]
        public string UserEmail { get; set; }
        public string Message { get; set; }
        public string GamespaceName { get; set; }

    }
}