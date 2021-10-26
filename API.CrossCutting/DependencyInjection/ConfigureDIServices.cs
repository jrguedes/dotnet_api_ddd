using API.Data.DatabaseContext;
using API.Data.Repositories;
using API.Domain.Interfaces.Services;
using API.Domain.Interfaces.Repositories;
using API.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API.Domain.Interfaces.Services.Login;
using API.Domain.Security;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace API.CrossCutting.DependencyInjection
{
    public class ConfigureDIServices
    {
        public static void ConfigureDI(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = "Server=192.168.64.2;Port=3306;Database=db_api_ddd;Uid=jrguedes;Pwd=senha@01;";
            services.AddDbContext<DataContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILoginService, LoginService>();                        
        }
    }
}
