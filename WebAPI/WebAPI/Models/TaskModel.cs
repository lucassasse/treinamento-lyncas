namespace WebAPI.Models
{
    public class TaskModel
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Descricao { get; set; }
        public int Status { get; set; }
    }
}
