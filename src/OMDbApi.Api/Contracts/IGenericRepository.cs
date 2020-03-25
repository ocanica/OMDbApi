using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMDbApi.Contracts
{
    public interface IGenericRepository<T>
        where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Get(string id);
        public Task Add(T entity);
        public void Remove(T entity);
    }
}
