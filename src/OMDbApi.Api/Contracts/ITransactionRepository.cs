using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMDbApi.Api.Models;

namespace OMDbApi.Api.Contracts
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task Transact(int userId, string imdbId);
        Task Transact(int userId, string imdbId, int rating);
    }
}
