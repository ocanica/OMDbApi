using Microsoft.EntityFrameworkCore;
using OMDbApi.Contracts;
using OMDbApi.Data;
using OMDbApi.Models;
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
            if (id == string.Empty)
                throw new ArgumentException();
            var user = _context.Users;
            if (user == null)
                throw new NullReferenceException();
            return await user.FirstOrDefaultAsync(u => u.Username == id);
        }

        public async Task Add(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            await _context.AddAsync(entity);
            _context.SaveChanges();
        }

        public void Remove(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            _context.RemoveRange(entity);
            _context.SaveChanges();
        }
    }
}
