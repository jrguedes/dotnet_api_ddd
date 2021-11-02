using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Mapping
{
    public class MunicipioMap : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("Municipio");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.CodIBGE)
                   .IsUnique();

            builder.HasOne(u => u.UF)
                   .WithMany(m => m.Municipios);
        }
    }
}
