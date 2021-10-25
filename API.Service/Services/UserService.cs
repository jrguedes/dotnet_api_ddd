using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Entities;
using API.Domain.Interfaces.Repositories;
using API.Domain.Interfaces.Services;

namespace API.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _repository;

        //nesta class monta a regra de negocio para as entradas caso necessário. As validações
        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<User> PostAsync(User user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<User> PutAsync(User user)
        {
            return await _repository.UpdateAsync(user);
        }        
    }
}
