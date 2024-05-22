using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Infrastructure.EntityConfiguration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder) 
        { 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Gender).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(150).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();

            builder.HasData(
                new Member(1, "Janis", "Joplin", "feminino", "janis@email.com", true),
                new Member(2, "Elvis", "Presley", "masculino", "elvis@email.com", true)
            );
        }
    }
}
