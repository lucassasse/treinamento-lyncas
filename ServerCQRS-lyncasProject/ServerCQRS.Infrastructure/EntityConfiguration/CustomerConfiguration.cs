using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Infrastructure.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Telephone).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Cpf).HasMaxLength(14).IsRequired();

            //builder.HasData(
            //    new Customer("Lucas Sasse", "lucas@email.com", "47963256985", "123.123.123.87", false, DateTime.Now),
            //    new Customer("Cliente Dois", "cliente@email.com", "4996589658", "321.321.321.78", false, DateTime.Now)
            //);
        }
    }
}
