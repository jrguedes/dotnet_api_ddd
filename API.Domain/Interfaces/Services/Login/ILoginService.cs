using System.Threading.Tasks;
using API.Domain.Entities;

namespace API.Domain.Interfaces.Services.Login
{
    public interface ILoginService
    {
         Task<object> FindByLogin(UserEntity user);
    }
}
