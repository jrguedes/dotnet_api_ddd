using System.Threading.Tasks;
using API.Domain.Entities;
using API.Domain.Interfaces.Repositories;
using API.Domain.Interfaces.Services.Login;

namespace API.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;

        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }
        
        public Task<object> FindByLogin(UserEntity user)
        {
            throw new System.NotImplementedException();
        }
    }
}
