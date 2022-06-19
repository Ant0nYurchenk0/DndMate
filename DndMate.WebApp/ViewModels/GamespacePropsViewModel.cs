using DndMate.WebApp.Dtos;
using System.Collections.Generic;

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