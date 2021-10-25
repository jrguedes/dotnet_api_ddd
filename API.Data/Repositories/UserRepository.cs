using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.DatabaseContext;
using API.Domain.Entities;
using API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly DataContext _context;
        private DbSet<UserEntity> _dataset;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
