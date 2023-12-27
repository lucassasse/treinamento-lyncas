using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Map;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class SistemTasksDBContext : DbContext
    {
        public SistemTasksDBContext(DbContextOptions<SistemTasksDBContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
