using OMDbApi.Api.Models;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface IMoviesRepository : IGenericRepository<Movie>
    {
        Task Add(int id, string title);
        Task Rate(int id, string imdbId, int rating);
    }
}
