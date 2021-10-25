using System.Threading.Tasks;
using API.Domain.Entities;

namespace API.Domain.Interfaces.Respositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
         Task<UserEntity> FindByLogin(string email);
    }
}
