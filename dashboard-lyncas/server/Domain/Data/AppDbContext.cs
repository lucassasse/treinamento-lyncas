using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class AppDbContext : DbContext
    {
        //public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(connectionString: "Server=localhost; Database=DashboardTest; Trusted_Connection=True; Encrypt=False;");
    }
}
