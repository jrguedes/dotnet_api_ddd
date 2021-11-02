using System.Threading.Tasks;
using API.Domain.Entities;

namespace API.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
         Task<Endereco> GetByCEPAsync(string cep);
    }
}
