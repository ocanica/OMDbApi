using OMDbApi.Api.Models;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface IRatingsRepository
    {
        public Task Add(Rating rating);
        public Rating CreateRating(int UserId, string IMDbId);
        public void Update(Rating rating);
        //public Rating Get(int userId, string movieId);
    }
}