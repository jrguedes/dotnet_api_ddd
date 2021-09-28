using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Data.DatabaseContext
{
    public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {            
            var connectionString = "Server=192.168.64.2;Port=3306;Database=db_api_ddd;Uid=jrguedes;Pwd=senha@01;";
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                        
            return new DataContext(optionsBuilder.Options);
        }
    }
}
