using OMDbApi.Api.Contracts;
using OMDbApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMDbApi.Api.Services
{
    public interface IMoviesRepository : IGenericRepository<Movie>
    {
        
    }
}
