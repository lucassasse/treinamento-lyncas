using Microsoft.EntityFrameworkCore;
using CustomerApiOnion.Domain.Models;

namespace CustomerApiOnion.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(connectionString: "Server=localhost; Database=CustomerApiOnion; Trusted_Connection=True; Encrypt=False;");
    }
}
