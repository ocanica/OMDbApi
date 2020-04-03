using OMDbApi.Api.Models;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<User> GetById(int id);
        Task<User> GetByUsername(string name);
        Task Remove(int id);
        object ReturnUserMovies(string username);
    }
}
