using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Infrastructure.EntityConfiguration
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasData(
            //    new Sale(DateTime.Now, DateTime.Now, 100.00, 200.00, 1, []),
            //    new Sale(DateTime.Now, DateTime.Now, 2500.00, 20000.00, 0, [])
            //);
        }
    }
}
