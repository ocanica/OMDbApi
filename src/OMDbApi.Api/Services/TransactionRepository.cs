using OMDbApi.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMDbApi.Api.Models;
using OMDbApi.Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace OMDbApi.Api.Services
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly OMDbContext _context;

        public TransactionRepository(OMDbContext context)
        {
            _context = context;
        }

        public async Task Add(Transaction entity)
        {
            entity.DateId = DateTime.Now;
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

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

        public Task Update(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public Task Save(Transaction entity)
        {
            throw new NotImplementedException();
        }

        // Attempt at abstracting and encapsulating transaction logic from the other repos
        public async Task Transact(int userId, string imdbId)
        {
            throw new NotImplementedException();
        }

        public Task Transact(int userId, string imdbId, int rating)
        {
            throw new NotImplementedException();
        }

        //public Transaction Transact(int userId, string imdbId)
        //{
        //    return new Transaction { UserId = userId, IMDbId = imdbId };
        //}
    }
}
