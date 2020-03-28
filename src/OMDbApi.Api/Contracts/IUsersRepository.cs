using OMDbApi.Api.Models;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<User> GetById(int id);
        Task Remove(int id);
    }
}
