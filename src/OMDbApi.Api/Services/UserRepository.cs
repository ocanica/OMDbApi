using Microsoft.EntityFrameworkCore;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Data;
using OMDbApi.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMDbApi.Api.Services
{
    public class UserRepository : IUserRepository
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

        public async Task<User> Get(string id)
        {
            var user = _context.Users;
            return await user.FirstOrDefaultAsync(u => u.FirstName == id);
        }

        public async Task Add(User entity)
        {
            await _context.AddAsync(entity);
            _context.SaveChanges();
        }

        public void Remove(User entity)
        {
            _context.RemoveRange(entity);
            _context.SaveChanges();
        }
    }
}
