using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Entities;

namespace API.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
         Task<T> InsertAsync(T entity);
         Task<T> UpdateAsync(T entity);         
         Task<bool> DeleteAsync(Guid id);
         Task<T> GetAsync(Guid id);
         Task<IEnumerable<T>> GetAsync();
         Task<bool> ExistsAsync(Guid id);
    }
}
