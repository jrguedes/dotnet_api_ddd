using API.Data.Mapping;
using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserEntity>(new UserMap().Configure);
        }

    }
}
