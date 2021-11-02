using System;
using API.Data.DatabaseContext;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTest //: IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTest()
        {
            var connectionString = $"Server=192.168.64.2;Port=3306;Database={dataBaseName};Uid=jrguedes;Pwd=senha@01;";
            var service = new ServiceCollection();
            service.AddDbContext<DataContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)/*,ServiceLifetime.Transient*/) // ServiceLifetime.Transient PESQUISAR DEPOIS - um banco pra cada requisição
            );

            ServiceProvider = service.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<DataContext>())
            {
                context.Database.EnsureCreated(); //criar o banco, roda as migrations
            }
        }

        /*
        public void Dispose()
        {
            
            using (var context = ServiceProvider.GetService<DataContext>())
            {
                context.Database.EnsureDeleted(); //banco de dados eliminado
            }
            
        } 
        */       

    }
}
