using Microsoft.EntityFrameworkCore;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Data;
using OMDbApi.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMDbApi.Api.Services
{
    public class UserRepository : IUsersRepository
    {
        private readonly OMDbContext _context;

        public UserRepository(OMDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(object id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == id.ToString());
        }

        public async Task Add(User entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(object id)
        {
            var entity = await GetById(id);
            _context.RemoveRange(entity);
            await _context.SaveChangesAsync();
        }
    }
}
