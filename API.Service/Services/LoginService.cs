using System.Threading.Tasks;
using API.Domain.Dtos;
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
        
        public async Task<object> FindByLogin(LoginDto login)
        {            
            if (login != null && !string.IsNullOrWhiteSpace(login.Email)){
                return await _repository.FindByLogin(login.Email);
            }
            return null;
        }
    }
}
