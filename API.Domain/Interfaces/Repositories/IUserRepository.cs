using System.Threading.Tasks;
using API.Domain.Entities;

namespace API.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
         Task<User> FindByLogin(string email);
    }
}
