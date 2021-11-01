using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Dtos.User;

namespace API.Domain.Interfaces.Services
{
    //responsavel pela regra de negocio
    //podem ter outros métodos para atender a regra de negocio além dos verbos
    public interface IUserService
    {
         Task<UserDto> GetAsync(Guid id);
         Task<IEnumerable<UserDto>> GetAllAsync();

         Task<UserDto> PostAsync(UserDto user);

         Task<UserDto> PutAsync(UserDto user);         

         Task<bool> DeleteAsync(Guid id);
    }
}
