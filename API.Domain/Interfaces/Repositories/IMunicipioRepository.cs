using System.Threading.Tasks;
using API.Domain.Entities;

namespace API.Domain.Interfaces.Repositories
{
    public interface IMunicipioRepository : IRepository<Municipio>
    {
         Task<Municipio> GetByCodIBGE(int codIBGE);
    }
}
