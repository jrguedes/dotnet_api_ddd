using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.DatabaseContext;
using API.Domain.Entities;
using API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataContext _context;
        private DbSet<User> _dataset;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
            _dataset = context.Set<User>();
        }

        public async Task<User> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
