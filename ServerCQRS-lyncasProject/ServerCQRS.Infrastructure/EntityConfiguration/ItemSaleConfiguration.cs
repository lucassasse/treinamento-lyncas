using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Infrastructure.EntityConfiguration
{
    public class ItemSaleConfiguration : IEntityTypeConfiguration<ItemSale>
    {
        public void Configure(EntityTypeBuilder<ItemSale> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasData(
            //    new ItemSale("Batatinha", 7, 12, 82),
            //    new ItemSale("Repolho", 2, 12, 24)
            //);
        }
    }
}
