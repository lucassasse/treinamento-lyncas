using MeuTodoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuTodoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Subtask> Subtasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(connectionString: "Server=localhost; Database=TutorialEF; Trusted_Connection=True; Encrypt=False;");
    }
}
