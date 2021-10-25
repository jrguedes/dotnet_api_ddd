using System.Threading.Tasks;
using API.Domain.Dtos;

namespace API.Domain.Interfaces.Services.Login
{
    public interface ILoginService
    {
         Task<object> FindByLogin(LoginDto login);
    }
}
