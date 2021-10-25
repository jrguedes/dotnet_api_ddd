using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Entities;
using API.Domain.Interfaces.Repositories;
using API.Domain.Interfaces.Services.User;

namespace API.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;

        //nesta class monta a regra de negocio para as entradas caso necessário. As validações
        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<UserEntity> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<UserEntity> PostAsync(UserEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<UserEntity> PutAsync(UserEntity user)
        {
            return await _repository.UpdateAsync(user);
        }        
    }
}
