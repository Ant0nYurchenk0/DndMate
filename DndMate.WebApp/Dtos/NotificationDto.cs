using DndMate.WebApp.Validations;

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