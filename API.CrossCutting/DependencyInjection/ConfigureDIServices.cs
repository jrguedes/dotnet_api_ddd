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
using System;
using API.Domain.Interfaces.Services.UF;
using API.Domain.Interfaces.Services.Endereco;
using API.Domain.Interfaces.Services.Municipio;

namespace API.CrossCutting.DependencyInjection
{
    public class ConfigureDIServices
    {
        public static void ConfigureDI(IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = "Server=192.168.64.2;Port=3306;Database=db_api_ddd;Uid=jrguedes;Pwd=senha@01;"; //DENTRO DO.vscode/launch.json para simulação das variaveis de ambiente
            var connectionString = string.Empty;

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "MYSQL".ToLower())
            {
                connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
            }

            services.AddDbContext<DataContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUFRepository, UFRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUFService, UFService>();
            services.AddTransient<IEnderecoService, EnderecoService>();
            services.AddTransient<IMunicipioService, MunicipioService>();

            services.AddTransient<ILoginService, LoginService>();                        
        }
    }
}
