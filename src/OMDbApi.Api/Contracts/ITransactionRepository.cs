using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMDbApi.Api.Models;

namespace OMDbApi.Api.Contracts
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task Transact(IGenericRepository<User> users, IGenericRepository<Movie> movies, User user, Movie movie);
        Task Transact(IGenericRepository<User> users, IGenericRepository<Movie> movies, IRatingsRepository ratings, User user, Movie movie, Rating rating);
        public Transaction CreateTransaction(User user, Movie movie);
    }
}
