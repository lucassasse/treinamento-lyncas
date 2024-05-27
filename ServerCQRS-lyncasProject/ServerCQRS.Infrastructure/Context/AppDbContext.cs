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

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<ItemSale> ItemSale { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MemberConfiguration());
        }

        protected override void OnCustomerCreating(CustomerBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
        }

        protected override void OnSaleCreating(SaleBuilder builder)
        {
            builder.ApplyConfiguration(new SaleConfiguration());
        }

        protected override void OnItemSaleCreating(ItemSaleBuilder builder)
        {
            builder.ApplyConfiguration(new ItemSaleConfiguration());
        }
    }
}
