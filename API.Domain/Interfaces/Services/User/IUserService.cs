using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Entities;

namespace API.Domain.Interfaces.Services.User
{
    //responsavel pela regra de negocio
    //podem ter outros métodos para atender a regra de negocio além dos verbos
    public interface IUserService
    {
         Task<UserEntity> GetAsync(Guid id);
         Task<IEnumerable<UserEntity>> GetAllAsync();

         Task<UserEntity> PostAsync(UserEntity user);

         Task<UserEntity> PutAsync(UserEntity user);         

         Task<bool> DeleteAsync(Guid id);
    }
}
