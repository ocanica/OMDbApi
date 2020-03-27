using OMDbApi.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMDbApi.Api.Models;
using OMDbApi.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace OMDbApi.Api.Services
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly OMDbContext _context;

        public TransactionRepository(OMDbContext context, IGenericRepository<User> userRepository, IGenericRepository<Movie> moviesRepository)
        {
            _context = context;
        }

        public async Task Add(Transaction entity)
        {
            throw new NotImplementedException();
        }

        /*public async Task AddMultiple(User user, Movie movie)
        {
            var transaction = _context.Movies;
            await transaction.FirstOrDefaultAsync(m => m.Equals == )
        }*/

        public Task<Transaction> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Transaction> GetAll()
        {
            return _context.Set<Transaction>().AsNoTracking();
        }

        public async Task Remove(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> Find(object predicate)
        {
            throw new NotImplementedException();
        }
    }
}
