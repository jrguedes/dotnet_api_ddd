using System;
using System.Threading.Tasks;
using API.Data.DatabaseContext;
using API.Data.Repositories;
using API.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace API.Data.Test
{
    public class UsuarioCRUDCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCRUDCompleto(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "User")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using(var context = _serviceProvider.GetService<DataContext>())
            {
                UserRepository repository = new UserRepository(context);
                User user = new User
                {
                    Email = "teste@mail.com",
                    Name = "teste",
                    Role = "Employee"
                };

                var registroCriado = await repository.InsertAsync(user);
                
                Assert.NotNull(registroCriado);
                Assert.Equal("teste@mail.com", registroCriado.Email);
                Assert.Equal("teste",registroCriado.Name);
                Assert.Equal("Employee",registroCriado.Role);
                Assert.False(registroCriado.Id == Guid.Empty);
            }
        }
    }
}
