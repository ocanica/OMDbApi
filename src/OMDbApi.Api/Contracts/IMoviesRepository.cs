using OMDbApi.Contracts;
using OMDbApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMDbApi.Contracts
{
    public interface IMoviesRepository : IGenericRepository<Movie>
    {
    }
}
