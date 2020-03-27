using OMDbApi.Api.Models;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface IMoviesRepository : IGenericRepository<Movie>
    {
        Task Add(string username, string title);
    }
}
