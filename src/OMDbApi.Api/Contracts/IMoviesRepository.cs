using OMDbApi.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface IMoviesRepository : IGenericRepository<Movie>
    {
        Task Add(int id, string title);
        Task<Movie> ReturnTitle(string title);
        //Task<Movie> GetByTitle(string title);
        Task<IEnumerable<MovieMinified>> ReturnTitles(string title);
    }
}
