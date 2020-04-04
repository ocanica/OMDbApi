using OMDbApi.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface IMoviesRepository : IGenericRepository<Movie>
    {
        Task<Movie> ReturnId(string imdbId);
        Task<Movie> ReturnTitle(string title);
        Task<IEnumerable<MovieMinified>> ReturnTitles(string title);
    }
}
