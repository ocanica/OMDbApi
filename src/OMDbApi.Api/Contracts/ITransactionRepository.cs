using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMDbApi.Api.Models;

namespace OMDbApi.Api.Contracts
{
    interface ITransactionRepository : IGenericRepository<Transaction>
    {
    }
}
