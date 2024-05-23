using Microsoft.EntityFrameworkCore;
using ServerCQRS.Domain.Entities;
using ServerCQRS.Infrastructure.EntityConfiguration;

namespace ServerCQRS.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MemberConfiguration());
        }
    }
}
