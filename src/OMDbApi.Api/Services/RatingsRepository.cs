using Microsoft.EntityFrameworkCore;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Data;
using OMDbApi.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OMDbApi.Api.Services
{
    public class RatingsRepository : IRatingsRepository
    {
        private readonly OMDbContext _context;
        public RatingsRepository(OMDbContext context)
        {
            _context = context;
        }

        public void Update(Rating rating)
        {
            _context.Update(rating);
        }

        public async Task<Rating> Get(int userId, string movieId)
        {
            Rating result = null;
            try
            {
                result = await _context.Ratings
                    .FirstOrDefaultAsync(c => c.UserId == userId && c.IMDbId == movieId);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            return result;
        }
    }
}
