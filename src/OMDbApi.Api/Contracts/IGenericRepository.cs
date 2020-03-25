using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface IGenericRepository<T>
        where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Get(T entity);
        public Task<T> Add(T entity);
        public Task<T> Remove(T entity);
    }
}
