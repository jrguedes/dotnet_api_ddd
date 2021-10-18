using API.Data.DatabaseContext;
using API.Data.Repositories;
using API.Domain.Interfaces;
using API.Domain.Interfaces.Services.User;
using API.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.CrossCutting.DependencyInjection
{
    public class ConfigureDIServices
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            var connectionString = "Server=192.168.64.2;Port=3306;Database=db_api_ddd;Uid=jrguedes;Pwd=senha@01;";
            services.AddDbContext<DataContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserService, UserService>();
        }
    }
}
