using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface IGenericRepository<T>
        where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetById(object id);
        Task Add(T entity);
        Task Remove(object id);
        void Update(T entity);
        Task Save(T entity);
        bool DoesExist(T enity);
    }
}
