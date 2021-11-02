using System;
using API.Data.Mapping;
using API.Data.Seeds;
using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<User>(new UserMap().Configure);
            builder.Entity<Municipio>(new MunicipioMap().Configure);
            builder.Entity<Endereco>(new EnderecoMap().Configure);
            builder.Entity<UF>(new UFMap().Configure);

            builder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Gerente",
                    Email = "gerente@gmail.com",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Role = "Manager"
                }                
            );
            
            UFSeeds.UFs(builder);
        }

    }
}
