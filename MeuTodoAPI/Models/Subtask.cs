namespace MeuTodoAPI.Models
{
    public class Subtask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }

        public int TodoId { get; set; } // Foreign key linking to Todo
    }
}
