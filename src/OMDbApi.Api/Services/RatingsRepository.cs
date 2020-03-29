using Microsoft.EntityFrameworkCore;
using OMDbApi.Api.Contracts;
using OMDbApi.Api.Data;
using OMDbApi.Api.Models;
using System;
using System.Collections.Generic;
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

        public async Task Add(Rating rating)
        {
            await _context.AddAsync(rating);
            await _context.SaveChangesAsync();
        }

        public async Task<Rating> Get(int userId, string movieId)
        {
            var result = await _context.Ratings
                .FirstOrDefaultAsync(c => c.UserId == userId && c.IMDbId == movieId);
            return result;
        }
    }
}
