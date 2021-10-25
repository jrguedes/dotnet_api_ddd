using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Entities;

namespace API.Domain.Interfaces.Services
{
    //responsavel pela regra de negocio
    //podem ter outros métodos para atender a regra de negocio além dos verbos
    public interface IUserService
    {
         Task<User> GetAsync(Guid id);
         Task<IEnumerable<User>> GetAllAsync();

         Task<User> PostAsync(User user);

         Task<User> PutAsync(User user);         

         Task<bool> DeleteAsync(Guid id);
    }
}
