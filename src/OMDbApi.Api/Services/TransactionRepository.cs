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
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
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

        public Task Remove(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public Task Save(Transaction entity)
        {
            throw new NotImplementedException();
        }

        //public async Task Transact(IGenericRepository<User> users, IGenericRepository<Movie> movies,
        //    User user, Movie movie)
        //{
        //    var transaction = CreateTransaction(user, movie);
        //    using var transact = _context.Database.BeginTransaction();
        //    try
        //    {
        //        await movies.Add(movie);
        //        users.Update(user);
        //        await Add(transaction);
        //        await _context.SaveChangesAsync();

        //        transact.Commit();
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e.Message);
        //        throw;
        //    }
        //}

        public async Task Transact(IGenericRepository<User> users, IGenericRepository<Movie> movies, 
            IRatingsRepository ratings, User user, Movie movie, Rating rating)
        {
            var transaction = CreateTransaction(user, movie);
            using var transact = _context.Database.BeginTransaction();
            try
            {
                await ratings.Add(rating);
                users.Update(user);
                await Add(transaction);
                await _context.SaveChangesAsync();

                transact.Commit();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public Transaction CreateTransaction(User user, Movie movie)
        {
            return new Transaction { UserId = user.UserId, IMDbId = movie.IMDbId, DateId = DateTime.Now };
        }

        public bool DoesExist(Transaction enity)
        {
            throw new NotImplementedException();
        }
    }
}
