using OMDbApi.Api.Models;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface IRatingsRepository
    {
        public void Update(Rating rating);
        public Task<Rating> Get(int userId, string movieId);
    }
}