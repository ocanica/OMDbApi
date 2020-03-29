using OMDbApi.Api.Models;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface IRatingsRepository
    {
        public Task Add(Rating rating);
        public Task<Rating> Get(int userId, string movieId);
    }
}