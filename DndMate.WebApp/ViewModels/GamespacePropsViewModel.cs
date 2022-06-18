﻿using DndMate.WebApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.ViewModels
{
    public class GamespacePropsViewModel
    {
        public GamespacePropsViewModel()
        {
            Characters = new List<GamespaceCharDto>();
        }
        public GamespaceDto Gamespace { get; set; }
        public GamespaceCharDto Character { get; set; }
        public NotificationDto Notification { get; set; }
        public IEnumerable<GamespaceCharDto> Characters { get; set; }
    }
}