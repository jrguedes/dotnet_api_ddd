using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Mapping
{
    public class UFMap : IEntityTypeConfiguration<UF>
    {
        public void Configure(EntityTypeBuilder<UF> builder)
        {
            builder.ToTable("UF");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Sigla)
                   .IsUnique();
        }
    }
}
