using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task Add(T entity);
        Task Remove(object id);
    }
}
