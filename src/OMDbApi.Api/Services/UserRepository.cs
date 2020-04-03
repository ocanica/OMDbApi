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
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
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
        public async Task<User> GetByUsername(string username)
        {
            var test = username;
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }
        public object GetUserMovies(string username)
        {
            var result = (from r in _context.Ratings
                          join m in _context.Movies on r.IMDbId equals m.IMDbId
                          join u in _context.Users on r.UserId equals u.UserId
                          where u.Username == username
                          select new { m.Title, r.MovieRating });

            return result;
        }

        public async Task Add(User entity)
        {
            entity.DateRegistered = DateTime.Now;
            entity.DateModified = DateTime.Now;
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Remove(int id)
        {
            var entity = await GetById(id);
            _context.RemoveRange(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(object id)
        {
            var entity = await GetById(id);
        
            _context.RemoveRange(entity);
            await _context.SaveChangesAsync();
        }
        public void Update(User entity)
        {
            entity.DateModified = DateTime.Now;
            _context.Update(entity);
        }

        public Task<User> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task Save(User entity)
        {
            throw new NotImplementedException();
        }

        public bool DoesExist(User enity)
        {
            throw new NotImplementedException();
        }
    }
}
