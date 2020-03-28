using Microsoft.EntityFrameworkCore;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Data;
using OMDbApi.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<User> GetAll()
        {
            return _context.Set<User>().AsNoTracking();
        }
        public async Task<User> GetById(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task Add(User entity)
        {
            entity.DateRegistered = DateTime.Now;
            entity.DateModified = DateTime.Now;
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(object id)
        {
            var entity = await GetById(id);
            _context.RemoveRange(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Find(object predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Update(User entity)
        {
            entity.DateModified = DateTime.Now;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public Task Save(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
