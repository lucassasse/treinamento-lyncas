using WebAPI.Enums;

namespace WebAPI.Models
{
    public class TaskModel
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusTask Status { get; set; }
    }
}
