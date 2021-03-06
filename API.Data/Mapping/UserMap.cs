using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email)
                   .IsUnique();
            
            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .HasMaxLength(60);
            
            builder.Property(u => u.Role)
                   .HasMaxLength(40);
        }
    }
}
